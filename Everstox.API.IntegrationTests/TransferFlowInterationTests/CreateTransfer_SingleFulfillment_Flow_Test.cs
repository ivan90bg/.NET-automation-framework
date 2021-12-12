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
            
            var transferRequest = GenerateTransferRequest();

            var transferService = new TransfersService();
            var transferResponse = await transferService.CreateTransfer(Shops.TestShop_Id, transferRequest);

            TransferValidations(transferRequest, transferResponse);

            // Accept transfer
            var acceptTransfer = new TransferAccept_Request() { accepted = true, transfer_number = transferResponse.Data.transfer_number };

            var warehouseTransferService = new TransfersWarehouseService();
            var acceptanceResponse = await warehouseTransferService.AcceptTransfer(WarehousesData.StorelogixQA1_Id, WarehousesData.StorelogixQA1_Connector, acceptTransfer);

            // Accept transfer validations
            AcceptedTransferValidations(acceptanceResponse);

            // Create transfer shipment model
            var transferShipment = new TransferShipment_Request()
            {
                transfer_items_updates = new List<TransferItemsUpdate> { new TransferItemsUpdate 
                                                                                                { quantity_received = 10,
                                                                                                  quantity_stocked = 9, 
                                                                                                  sku = acceptanceResponse.Data.transfer_items[0].sku }
                },
                transfer_number = acceptanceResponse.Data.transfer_number
            };
            var receiveTransferShipmentResponse = await warehouseTransferService.ReceiveTransferShipment(WarehousesData.StorelogixQA1_Id, WarehousesData.StorelogixQA1_Connector, transferShipment);

            TransferShipmentValidations(transferShipment, receiveTransferShipmentResponse);

            // Complete transfer
            var transferCompletion = new TransferComplete_Request();
            var completedTransferResponse = await transferService.CompleteTransfer(Shops.TestShop_Id, receiveTransferShipmentResponse.Data.id, transferCompletion);

            TrasferCompletionValidations(completedTransferResponse);
        }

        private static Transfer_Request GenerateTransferRequest()
        {
            return new Transfer_Request()
            {
                destination = WarehousesData.StorelogixQA1_Id,
                source = "custom source",
                transfer_items = new List<TransferItem_T> { new TransferItem_T() { quantity_announced = 15, sku = "CartP" } },
                transfer_number = $"Transfer - {Guid.NewGuid()}"

            };
        }

        private static void TrasferCompletionValidations(IRestResponse<Transfer_Response> completedTransferResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, completedTransferResponse.StatusCode, completedTransferResponse.Content.ToString());
            Assert.AreEqual(EnumString.GetStringValue(Transfer_State.Completed), completedTransferResponse.Data.state);
        }

        private static void TransferShipmentValidations(TransferShipment_Request transferShipment, IRestResponse<TransferShipment_Response> receiveTransferShipmentResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, receiveTransferShipmentResponse.StatusCode);
            Assert.AreEqual(transferShipment.transfer_items_updates[0].quantity_received, receiveTransferShipmentResponse.Data.transfer_shipments[0].transfer_shipment_items[0].quantity_received);
            Assert.AreEqual(transferShipment.transfer_items_updates[0].quantity_stocked, receiveTransferShipmentResponse.Data.transfer_shipments[0].transfer_shipment_items[0].quantity_stocked);
        }

        private static void AcceptedTransferValidations(IRestResponse<Transfer_Response> acceptanceResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, acceptanceResponse.StatusCode, acceptanceResponse.Content.ToString());
            Assert.AreEqual(EnumString.GetStringValue(Transfer_State.In_progress), acceptanceResponse.Data.state);
            Assert.AreEqual(EnumString.GetStringValue(Transfer_State.In_progress), acceptanceResponse.Data.transfer_items[0].state);
        }

        private static void TransferValidations(Transfer_Request transferRequest, IRestResponse<Transfer_Response> transferResponse)
        {
            Assert.AreEqual(HttpStatusCode.Created, transferResponse.StatusCode, transferResponse.Content.ToString());
            Assert.AreEqual(transferRequest.transfer_number, transferResponse.Data.transfer_number);
            Assert.AreEqual(EnumString.GetStringValue(Transfer_State.Transmission_to_warehouse_pending), transferResponse.Data.state);
            Assert.AreEqual(EnumString.GetStringValue(Warehouse_Names.Storelogix), transferResponse.Data.destination_name);
        }

    }
}
