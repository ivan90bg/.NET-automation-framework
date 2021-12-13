using System.Reflection;

namespace Everstox.Infrastructure.Infrastructure_Data
{
    public static class EverstoxAPIData
    {
        public enum Warehouse_Names
        {
            [EnumValue("Finecom QA1")]
            Finecom = 0,
            [EnumValue("Storelogix QA1")]
            Storelogix = 1,
            [EnumValue("Demo warehouse QA1")]
            Demo_Warehouse = 2,
            [EnumValue("Bolec Warehouse")]
            Bolec_Warehouse = 3
        }

        public enum Fulfillment_State
        {
            [EnumValue("warehouse_confirmation_pending")]
            Warehouse_confirmation_pending = 0,
            [EnumValue("accepted_by_connectorg")]
            Accepted_by_connector = 1,
            [EnumValue("accepted_by warehouse")]
            Accepted_by_warehouse = 2,
            [EnumValue("in_fulfillment")]
            In_Fullfilment = 3,
            [EnumValue("partially_shipped")]
            Partially_shipped = 4,
            [EnumValue("shipped")]
            Shipped = 5,
            [EnumValue("canceled")]
            Canceled = 6,
            [EnumValue("rejected_by_warehouse")]
            Rejected_by_warehouse = 7,
            [EnumValue("completed")]
            Completed = 8,

        }

        public enum Cancellation_State
        {
            [EnumValue("connector_confirmation_pending")]
            Connector_confirmation_pending = 0,
            [EnumValue("accepted_by_connectorg")]
            Accepted_by_connector = 1,
            [EnumValue("cancellation_pending_by_warehouse")]
            Cancellation_pending_by_warehouse = 2,
            [EnumValue("canceled")]
            Canceled = 3,
            [EnumValue("completed")]
            Completed = 4,
            [EnumValue("rejected")]
            Rejected = 5

        }

        public enum Stock_State
        {
            [EnumValue("active")]
            Active = 0,
            [EnumValue("inactive")]
            Inactive = 1
        }

        public enum Transfer_State
        {
            [EnumValue("transmission_to_warehouse_pending")]
            Transmission_to_warehouse_pending = 0,
            [EnumValue("transmitted_to_warehouse")]
            Transmitted_to_warehouse = 1,
            [EnumValue("accepted_by_warehouse")]
            Accepted_by_warehouse = 2,
            [EnumValue("in_progress")]
            In_progress = 3,
            [EnumValue("completed")]
            Completed = 4,
            [EnumValue("rejected_by_warehouse")]
            Rejected_by_warehouse = 5
        }

        public class EnumValue : Attribute
        {
            private string _value;
            public EnumValue(string value)
            {
                _value = value;
            }
            public string Value
            {
                get { return _value; }
            }
        }

        public static class EnumString
        {
            public static string GetStringValue(Enum value)
            {
                string output = null;
                Type type = value.GetType();
                FieldInfo fi = type.GetField(value.ToString());
                EnumValue[] attrs = fi.GetCustomAttributes(typeof(EnumValue), false) as EnumValue[];
                if (attrs.Length > 0)
                {
                    output = attrs[0].Value;
                }
                return output;
            }
        }
    }

}
