using Everstox.API.IntegrationTests.Static_Data;
using Everstox.API.Shop.Transfers;
using Everstox.API.Shop.Transfers.Models.Request_Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Everstox.API.UnitTests
{
    public class TransferTests
    {
        
        [Theory]
        [InlineData("Storelogix QA1", "source for Storelogix")]
        [InlineData("Finecom QA1", "source for Finecom")]
        [InlineData("Bolec Warehouse", "source for Bolec")]
        public async Task CreateTransfer_WithValidDestination_ShouldReturnCorrectStatusCode(string destination_name, string source)
        {
            var transfer = new Transfer_Request()
            {
                custom_attributes = new List<CustomAttribute_T_Req>() { new CustomAttribute_T_Req() { attribute_key = "custom key1", attribute_value = "custom value1" } },
                destination_name = destination_name,
                source = source,
                transfer_items = new List<TransferItem_T_Req>() { new TransferItem_T_Req() { sku = "str8", quantity_announced = 10 },
                                                            new TransferItem_T_Req() { sku = "ArmC", quantity_announced = 10 },
                                                            new TransferItem_T_Req() { sku = "beer", quantity_announced = 10 }},
                transfer_number = $"Transfer - {Guid.NewGuid()}"
            };

            var transferService = new TransfersService();
            var response = await transferService.CreateTransfer(Shops.TestShop_Id, transfer);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(transfer.source, response.Data.source);
            Assert.Equal(transfer.destination_name, response.Data.destination_name);
            Assert.Equal(transfer.transfer_number, response.Data.transfer_number);
            Assert.Equal(transfer.transfer_items[0].quantity_announced, response.Data.transfer_items[0].quantity_announced);
            Assert.Equal(transfer.transfer_items[1].quantity_announced, response.Data.transfer_items[1].quantity_announced);
            Assert.Equal(transfer.transfer_items[2].quantity_announced, response.Data.transfer_items[2].quantity_announced);
        }
    }
}