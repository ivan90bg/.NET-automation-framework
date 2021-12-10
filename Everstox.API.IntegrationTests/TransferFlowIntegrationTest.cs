using Everstox.API.IntegrationTests.Static_Data;
using Everstox.API.Shop.Transfers;
using Everstox.API.Shop.Transfers.Models.Request_Models;
using Everstox.API.Warehouses.Transfers;
using Everstox.API.Warehouses.Transfers.Models.Request_Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Everstox.API.IntegrationTests
{
    [TestClass]
    public class TransferFlowIntegrationTest
    {
        [TestMethod]
        public async Task CreateTransferFlow_WithProvidedSteps_ShouldReturnCorrectStatusCode()
        {
            // Create transfer model
            var transferRequest = new Transfer_Request_Model()
            {
                destination = WarehousesData.StorelogixQA1_Id,
                source = "custom source",
                transfer_items = new List<TransferItem> { new TransferItem() { quantity_announced = 15, sku = "CartP" } },
                transfer_number = "Automation Transfer 9"

            };

            // Create transfer
            var transferService = new TransfersService();
            var transferResponse = await transferService.CreateTransfer(Shops.TestShop_Id, transferRequest);

            // Transfer validations
            Assert.AreEqual(HttpStatusCode.Created, transferResponse.StatusCode, transferResponse.Content.ToString());
            Assert.AreEqual(transferRequest.transfer_number, transferResponse.Data.transfer_number);
            Assert.AreEqual("transmission_to_warehouse_pending", transferResponse.Data.state);
            Assert.AreEqual("Storelogix QA1", transferResponse.Data.destination_name);

            // Accept transfer
            var acceptTransfer = new Accept_Transfer_Model() { accepted = true, transfer_number = transferResponse.Data.transfer_number };

            var warehouseTransferService = new TransfersWarehouseService();
            var acceptanceResponse = await warehouseTransferService.AcceptTransfer(WarehousesData.StorelogixQA1_Id, WarehousesData.StorelogixQA1_Connector, acceptTransfer);

            // Accept transfer validations
            Assert.AreEqual(HttpStatusCode.Created, acceptanceResponse.StatusCode, acceptanceResponse.Content.ToString());
            Assert.AreEqual("in_progress", acceptanceResponse.Data.state);
            Assert.AreEqual("in_progress", acceptanceResponse.Data.transfer_items[0].state);

            // Create transfer shipment model
            var transferShipment = new Receive_TransferShipment_Model()
            {
                transfer_items_updates = new List<TransferItemsUpdate> { new TransferItemsUpdate { quantity_received = 10, quantity_stocked = 9, sku = acceptanceResponse.Data.transfer_items[0].sku } },
                transfer_number = acceptanceResponse.Data.transfer_number
            };
            var receiveTransferShipmentResponse = await warehouseTransferService.ReceiveTransferShipment(WarehousesData.StorelogixQA1_Id, WarehousesData.StorelogixQA1_Connector, transferShipment);
           
            // Transfer shipment validations
            Assert.AreEqual(HttpStatusCode.Created, receiveTransferShipmentResponse.StatusCode);
            Assert.AreEqual(transferShipment.transfer_items_updates[0].quantity_received, receiveTransferShipmentResponse.Data.transfer_shipments[0].transfer_shipment_items[0].quantity_received);
            Assert.AreEqual(transferShipment.transfer_items_updates[0].quantity_stocked, receiveTransferShipmentResponse.Data.transfer_shipments[0].transfer_shipment_items[0].quantity_stocked);

            // Complete transfer
            var transferCompletion = new Complete_Transfer_Model();
            var completedTransferResponse = await transferService.CompleteTransfer(Shops.TestShop_Id, receiveTransferShipmentResponse.Data.id, transferCompletion);

            // Transfer completion validations
            Assert.AreEqual(HttpStatusCode.Created, completedTransferResponse.StatusCode, completedTransferResponse.Content.ToString());
            Assert.AreEqual("completed", completedTransferResponse.Data.state);
        }
    }
}
