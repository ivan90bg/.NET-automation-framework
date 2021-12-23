using Everstox.API.IntegrationTests.Static_Data;
using Everstox.API.Shop.Transfers;
using Everstox.API.Shop.Transfers.Models.Request_Models;
using Everstox.API.Shop.Transfers.Models.Response_Models;
using Everstox.API.Warehouses.Transfers;
using Everstox.API.Warehouses.Transfers.Models.Request_Models;
using Everstox.API.Warehouses.Transfers.Models.Response_Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using static Everstox.Infrastructure.Infrastructure_Data.EverstoxAPIData;

namespace Everstox.API.IntegrationTests.TransferFlowInterationTests
{
    [TestClass]
    public class CreateTransfer_SingleFulfillment_Flow_Test
    {
        [TestMethod]
        public async Task CreateTransfer_SingleFulfillment_CompleteFlow_Test()
        {

            var transferRequest = CreateTransferRequest();
            var transferResponse = await CreateTransfer(transferRequest);

            ValidateTransfer(transferResponse);

            var acceptTransferRequest = CreateRequestForTransferAcceptance(transferResponse);
            var acceptTransferResponse = await AcceptTransfer(acceptTransferRequest);

            ValidateAcceptedTransfer(acceptTransferResponse);

            var transferShipmentRequest = CreateTransferShipmentRequest(acceptTransferResponse);
            var receiveTransferShipmentResponse = await ReceiveTransferShipment(transferShipmentRequest);

            ValidateTransferShipment(transferShipmentRequest, receiveTransferShipmentResponse);

            var completedTransferResponse = await CompleteTransfer(receiveTransferShipmentResponse);

            ValidateCompletedTransfer(completedTransferResponse);
        }


        private Transfer_Request CreateTransferRequest()
        {
            return new Transfer_Request()
            {
                destination = WarehousesData.StorelogixQA1_Id,
                source = "custom source",
                transfer_items = new List<TransferItem_T_Req> { new TransferItem_T_Req() { quantity_announced = 15, sku = "CartP" } },
                transfer_number = $"AutomationTransfer_{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5)}"

            };
        }

        private async Task<IRestResponse<Transfer_Response>> CreateTransfer(Transfer_Request transferRequest)
        {
            var transferService = new TransfersService();
            return await transferService.CreateTransfer(Shops.TestShop_Id, transferRequest);

        }

        private void ValidateTransfer(IRestResponse<Transfer_Response> transferResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, transferResponse.StatusCode, transferResponse.Content.ToString());
            Assert.AreEqual(EnumString.GetStringValue(Transfer_State.Transmission_to_warehouse_pending), transferResponse.Data.state);
            Assert.AreEqual(EnumString.GetStringValue(Warehouse_Names.Storelogix), transferResponse.Data.destination_name);
        }

        private TransferAccept_Request CreateRequestForTransferAcceptance(IRestResponse<Transfer_Response> transferResponse)
        {
            return new TransferAccept_Request() { accepted = true, transfer_number = transferResponse.Data.transfer_number };
        }

        private async Task<IRestResponse<Transfer_Response>> AcceptTransfer(TransferAccept_Request acceptTransferRequest)
        {
            var transferWarehouseService = new TransfersWarehouseService();
            return await transferWarehouseService.AcceptTransfer(WarehousesData.StorelogixQA1_Id, WarehousesData.StorelogixQA1_Connector, acceptTransferRequest);
           
        }

        private void ValidateAcceptedTransfer(IRestResponse<Transfer_Response> acceptedTransferResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, acceptedTransferResponse.StatusCode, acceptedTransferResponse.Content.ToString());
            Assert.AreEqual(EnumString.GetStringValue(Transfer_State.In_progress), acceptedTransferResponse.Data.state);
            Assert.AreEqual(EnumString.GetStringValue(Transfer_State.In_progress), acceptedTransferResponse.Data.transfer_items[0].state);
        }

        private TransferShipment_Request CreateTransferShipmentRequest(IRestResponse<Transfer_Response> acceptTransferResponse)
        {
            return new TransferShipment_Request()
            {
                transfer_items_updates = new List<TransferItemsUpdate> { new TransferItemsUpdate
                                                                                                { quantity_received = 10,
                                                                                                  quantity_stocked = 9,
                                                                                                  sku = acceptTransferResponse.Data.transfer_items[0].sku }
                },
                transfer_number = acceptTransferResponse.Data.transfer_number
            };
        }

        private async Task<IRestResponse<TransferShipment_Response>> ReceiveTransferShipment(TransferShipment_Request transferShipment)
        {
            var transfersWarehouseService = new TransfersWarehouseService();
            return await transfersWarehouseService.ReceiveTransferShipment(WarehousesData.StorelogixQA1_Id, WarehousesData.StorelogixQA1_Connector, transferShipment);

        }

        private void ValidateTransferShipment(TransferShipment_Request transferShipment, IRestResponse<TransferShipment_Response> receiveTransferShipmentResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, receiveTransferShipmentResponse.StatusCode);
            Assert.AreEqual(transferShipment.transfer_items_updates[0].quantity_received, receiveTransferShipmentResponse.Data.transfer_shipments[0].transfer_shipment_items[0].quantity_received);
            Assert.AreEqual(transferShipment.transfer_items_updates[0].quantity_stocked, receiveTransferShipmentResponse.Data.transfer_shipments[0].transfer_shipment_items[0].quantity_stocked);
        }

        private async Task<IRestResponse<Transfer_Response>> CompleteTransfer(IRestResponse<TransferShipment_Response> receiveTransferShipmentResponse)
        {
            var transferCompletionRequest = new TransferComplete_Request();
            var transfersService = new TransfersService();
            return await transfersService.CompleteTransfer(Shops.TestShop_Id, receiveTransferShipmentResponse.Data.id, transferCompletionRequest);
           
        }

        private void ValidateCompletedTransfer(IRestResponse<Transfer_Response> completedTransferResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, completedTransferResponse.StatusCode, completedTransferResponse.Content.ToString());
            Assert.AreEqual(EnumString.GetStringValue(Transfer_State.Completed), completedTransferResponse.Data.state);
        }

    }
}
