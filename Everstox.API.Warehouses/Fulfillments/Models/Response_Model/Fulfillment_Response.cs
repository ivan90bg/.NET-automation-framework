using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everstox.API.Warehouses.Fulfillments.Models.Response_Model
{
    public class Fulfillment_Response
    {
        public List<string> errors { get; set; }
        public List<string> success { get; set; }
    }
}
