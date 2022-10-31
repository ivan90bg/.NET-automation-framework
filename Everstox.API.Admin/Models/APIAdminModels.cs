using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everstox.API.Admin.Models
{
    public class APIAdminModels
    {

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Carrier
        {
            [Newtonsoft.Json.JsonProperty("dummy_tr_generator", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Dummy_tr_generator { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("shop", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Shop2 Shop { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            [Newtonsoft.Json.JsonProperty("tracking_url_template", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Tracking_url_template { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Carrier_create_update
        {
            [Newtonsoft.Json.JsonProperty("creation_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Creation_date { get; set; }

            [Newtonsoft.Json.JsonProperty("dummy_tr_generator", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Dummy_tr_generator { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("shop_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Shop_id { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            [Newtonsoft.Json.JsonProperty("tracking_url_template", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Tracking_url_template { get; set; }

            [Newtonsoft.Json.JsonProperty("updated_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Updated_date { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Complete_order_shipment
        {
            [Newtonsoft.Json.JsonProperty("carrier_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Carrier_id { get; set; }

            [Newtonsoft.Json.JsonProperty("notify_customer", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool? Notify_customer { get; set; }

            [Newtonsoft.Json.JsonProperty("set_hours_late_zero", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool? Set_hours_late_zero { get; set; }

            [Newtonsoft.Json.JsonProperty("shipment_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Shipment_date { get; set; }

            [Newtonsoft.Json.JsonProperty("tracking_code", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Tracking_code { get; set; }

            [Newtonsoft.Json.JsonProperty("tracking_codes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<string> Tracking_codes { get; set; }

            [Newtonsoft.Json.JsonProperty("tracking_urls", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<string> Tracking_urls { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Error_log
        {
            [Newtonsoft.Json.JsonProperty("acknowledged_by", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Acknowledged_by Acknowledged_by { get; set; }

            [Newtonsoft.Json.JsonProperty("acknowledged_comment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Acknowledged_comment { get; set; }

            [Newtonsoft.Json.JsonProperty("acknowledged_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Acknowledged_date { get; set; }

            [Newtonsoft.Json.JsonProperty("comments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Comments { get; set; }

            [Newtonsoft.Json.JsonProperty("creation_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Creation_date { get; set; }

            [Newtonsoft.Json.JsonProperty("entity_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Entity_id { get; set; }

            /// <summary>
            /// import/export
            /// </summary>
            [Newtonsoft.Json.JsonProperty("entity_type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Entity_type { get; set; }

            [Newtonsoft.Json.JsonProperty("error_code", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<string> Error_code { get; set; }

            [Newtonsoft.Json.JsonProperty("error_message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Error_message { get; set; }

            [Newtonsoft.Json.JsonProperty("export_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Export_id { get; set; }

            [Newtonsoft.Json.JsonProperty("from_service", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string From_service { get; set; }

            [Newtonsoft.Json.JsonProperty("history", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<object> History { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Id { get; set; }

            [Newtonsoft.Json.JsonProperty("import_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Import_id { get; set; }

            [Newtonsoft.Json.JsonProperty("updated_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Updated_date { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Error_log_acknowledge
        {
            [Newtonsoft.Json.JsonProperty("acknowledged_comment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Acknowledged_comment { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Error_log_create_update
        {
            [Newtonsoft.Json.JsonProperty("comments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Comments { get; set; }

            [Newtonsoft.Json.JsonProperty("entity_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Entity_id { get; set; }

            /// <summary>
            /// import/export
            /// </summary>
            [Newtonsoft.Json.JsonProperty("entity_type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Entity_type { get; set; }

            [Newtonsoft.Json.JsonProperty("error_code", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<string> Error_code { get; set; }

            [Newtonsoft.Json.JsonProperty("error_message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Error_message { get; set; }

            [Newtonsoft.Json.JsonProperty("export_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Export_id { get; set; }

            [Newtonsoft.Json.JsonProperty("from_service", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string From_service { get; set; }

            [Newtonsoft.Json.JsonProperty("history", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<object> History { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Id { get; set; }

            [Newtonsoft.Json.JsonProperty("import_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Import_id { get; set; }

            [Newtonsoft.Json.JsonProperty("response_body", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public object Response_body { get; set; }

            [Newtonsoft.Json.JsonProperty("response_code", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Response_code { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Export_http
        {
            [Newtonsoft.Json.JsonProperty("body", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public object Body { get; set; }

            [Newtonsoft.Json.JsonProperty("can_resolve", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Can_resolve { get; set; }

            [Newtonsoft.Json.JsonProperty("can_retry", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Can_retry { get; set; }

            [Newtonsoft.Json.JsonProperty("context", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public object Context { get; set; }

            [Newtonsoft.Json.JsonProperty("creation_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Creation_date { get; set; }

            [Newtonsoft.Json.JsonProperty("handler_fn_path", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Handler_fn_path { get; set; }

            [Newtonsoft.Json.JsonProperty("headers", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public object Headers { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("method", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Method { get; set; }

            /// <summary>
            /// new, in_progress, exported or error
            /// </summary>
            [Newtonsoft.Json.JsonProperty("state", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string State { get; set; }

            [Newtonsoft.Json.JsonProperty("updated_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Updated_date { get; set; }

            [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Url { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Feature_flag
        {
            [Newtonsoft.Json.JsonProperty("default_enabled", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Default_enabled { get; set; }

            [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Description { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Import
        {
            [Newtonsoft.Json.JsonProperty("can_resolve", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Can_resolve { get; set; }

            [Newtonsoft.Json.JsonProperty("can_retry", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Can_retry { get; set; }

            [Newtonsoft.Json.JsonProperty("creation_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Creation_date { get; set; }

            [Newtonsoft.Json.JsonProperty("data_in", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Data_in { get; set; }

            [Newtonsoft.Json.JsonProperty("errors", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public object Errors { get; set; }

            [Newtonsoft.Json.JsonProperty("exception", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Exception { get; set; }

            [Newtonsoft.Json.JsonProperty("handler_fn_path", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Handler_fn_path { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("item_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Item_id { get; set; }

            [Newtonsoft.Json.JsonProperty("item_type", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Item_type { get; set; }

            [Newtonsoft.Json.JsonProperty("parent_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Parent_id { get; set; }

            [Newtonsoft.Json.JsonProperty("resolved", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool? Resolved { get; set; }

            /// <summary>
            /// User id
            /// </summary>
            [Newtonsoft.Json.JsonProperty("resolved_by_user_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Resolved_by_user_id { get; set; }

            [Newtonsoft.Json.JsonProperty("resolved_comment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Resolved_comment { get; set; }

            [Newtonsoft.Json.JsonProperty("resolved_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Resolved_date { get; set; }

            [Newtonsoft.Json.JsonProperty("response_body", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public object Response_body { get; set; }

            [Newtonsoft.Json.JsonProperty("response_code", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Response_code { get; set; }

            /// <summary>
            /// in_progress, imported or error
            /// </summary>
            [Newtonsoft.Json.JsonProperty("state", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string State { get; set; }

            [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Type { get; set; }

            [Newtonsoft.Json.JsonProperty("updated_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Updated_date { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Import_export_resolve
        {
            /// <summary>
            /// User id
            /// </summary>
            [Newtonsoft.Json.JsonProperty("resolved_by_user_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Resolved_by_user_id { get; set; }

            [Newtonsoft.Json.JsonProperty("resolved_comment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Resolved_comment { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Maintenance_script
        {
            [Newtonsoft.Json.JsonProperty("body", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public object Body { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Maintenance_scripts_history
        {
            [Newtonsoft.Json.JsonProperty("auth_token", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Auth_token { get; set; }

            [Newtonsoft.Json.JsonProperty("body", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Body { get; set; }

            [Newtonsoft.Json.JsonProperty("exec_by_user_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Exec_by_user_id { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("response", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Response { get; set; }

            [Newtonsoft.Json.JsonProperty("response_code", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Response_code { get; set; }

            [Newtonsoft.Json.JsonProperty("script_name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Script_name { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Payment_method
        {
            [Newtonsoft.Json.JsonProperty("creation_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Creation_date { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("shop", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Shop3 Shop { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            [Newtonsoft.Json.JsonProperty("updated_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Updated_date { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Payment_method_create_update
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("shop_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Shop_id { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Product
        {
            [Newtonsoft.Json.JsonProperty("batch_product", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Batch_product { get; set; }

            [Newtonsoft.Json.JsonProperty("color", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Color { get; set; }

            [Newtonsoft.Json.JsonProperty("country_of_origin", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Country_of_origin { get; set; }

            [Newtonsoft.Json.JsonProperty("creation_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Creation_date { get; set; }

            [Newtonsoft.Json.JsonProperty("customs_code", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Customs_code { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("ignore_during_import", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Ignore_during_import { get; set; }

            [Newtonsoft.Json.JsonProperty("image_urls", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<Image_urls> Image_urls { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("size", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Size { get; set; }

            [Newtonsoft.Json.JsonProperty("sku", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Sku { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            [Newtonsoft.Json.JsonProperty("units", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<Product_unit> Units { get; set; }

            [Newtonsoft.Json.JsonProperty("updated_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Updated_date { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Product_create_update
        {
            [Newtonsoft.Json.JsonProperty("batch_product", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Batch_product { get; set; }

            [Newtonsoft.Json.JsonProperty("color", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Color { get; set; }

            [Newtonsoft.Json.JsonProperty("country_of_origin", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Country_of_origin { get; set; }

            [Newtonsoft.Json.JsonProperty("customs_code", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Customs_code { get; set; }

            [Newtonsoft.Json.JsonProperty("ignore_during_import", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Ignore_during_import { get; set; }

            [Newtonsoft.Json.JsonProperty("image_urls", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<Image_urls2> Image_urls { get; set; }

            /// <summary>
            /// Name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("size", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Size { get; set; }

            /// <summary>
            /// SKU.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("sku", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Sku { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            [Newtonsoft.Json.JsonProperty("units", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<Product_unit_create_update> Units { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Product_unit
        {
            [Newtonsoft.Json.JsonProperty("base_unit_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Base_unit_id { get; set; }

            [Newtonsoft.Json.JsonProperty("base_unit_name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Base_unit_name { get; set; }

            [Newtonsoft.Json.JsonProperty("default_unit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Default_unit { get; set; }

            [Newtonsoft.Json.JsonProperty("gtin", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Gtin { get; set; }

            [Newtonsoft.Json.JsonProperty("height_in_cm", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Height_in_cm { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("length_in_cm", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Length_in_cm { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("quantity_of_base_unit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Quantity_of_base_unit { get; set; }

            [Newtonsoft.Json.JsonProperty("weight_gross_in_kg", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Weight_gross_in_kg { get; set; }

            [Newtonsoft.Json.JsonProperty("weight_net_in_kg", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Weight_net_in_kg { get; set; }

            [Newtonsoft.Json.JsonProperty("width_in_cm", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Width_in_cm { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Product_unit_create_update
        {
            [Newtonsoft.Json.JsonProperty("default_unit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Default_unit { get; set; }

            [Newtonsoft.Json.JsonProperty("gtin", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Gtin { get; set; }

            [Newtonsoft.Json.JsonProperty("height_in_cm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Height_in_cm { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("length_in_cm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Length_in_cm { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("quantity_of_base_unit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Quantity_of_base_unit { get; set; }

            [Newtonsoft.Json.JsonProperty("weight_gross_in_kg", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Weight_gross_in_kg { get; set; }

            [Newtonsoft.Json.JsonProperty("weight_net_in_kg", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Weight_net_in_kg { get; set; }

            [Newtonsoft.Json.JsonProperty("width_in_cm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Width_in_cm { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shipment_option
        {
            [Newtonsoft.Json.JsonProperty("creation_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Creation_date { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("shipment_option_aliases", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<Shipment_option_aliases> Shipment_option_aliases { get; set; }

            [Newtonsoft.Json.JsonProperty("shop", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Shop4 Shop { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            [Newtonsoft.Json.JsonProperty("updated_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Updated_date { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shipment_option_alias
        {
            [Newtonsoft.Json.JsonProperty("creation_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Creation_date { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("shipment_option", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Shipment_option2 Shipment_option { get; set; }

            [Newtonsoft.Json.JsonProperty("shop", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Shop5 Shop { get; set; }

            [Newtonsoft.Json.JsonProperty("updated_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Updated_date { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shipment_option_alias_create_update
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("shipment_option_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Shipment_option_id { get; set; }

            [Newtonsoft.Json.JsonProperty("shop_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Shop_id { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shipment_option_create_update
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("shop_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Shop_id { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shipment_option_x_carrier
        {
            [Newtonsoft.Json.JsonProperty("carrier_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Carrier_id { get; set; }

            [Newtonsoft.Json.JsonProperty("creation_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Creation_date { get; set; }

            [Newtonsoft.Json.JsonProperty("shipment_option_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Shipment_option_id { get; set; }

            [Newtonsoft.Json.JsonProperty("updated_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Updated_date { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shipment_option_x_shop_warehouse
        {
            [Newtonsoft.Json.JsonProperty("creation_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Creation_date { get; set; }

            /// <summary>
            /// Shop instance X Shop X Warehouse ID.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            /// <summary>
            /// Order priority based on shipment option and warehouse.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("priority", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Priority { get; set; }

            [Newtonsoft.Json.JsonProperty("shipment_option", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Shipment_option3 Shipment_option { get; set; }

            [Newtonsoft.Json.JsonProperty("updated_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Updated_date { get; set; }

            [Newtonsoft.Json.JsonProperty("warehouse", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Warehouse2 Warehouse { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shipment_option_x_shop_warehouse_create_update
        {
            /// <summary>
            /// Shop instance X Shop X Warehouse ID.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Id { get; set; }

            /// <summary>
            /// Order priority based on shipment option and warehouse.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("priority", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Priority { get; set; }

            /// <summary>
            /// Shipment option ID.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("shipment_option_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Shipment_option_id { get; set; }

            /// <summary>
            /// Warehouse ID.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("warehouse_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Warehouse_id { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop
        {
            /// <summary>
            /// Shop ID.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Id { get; set; }

            /// <summary>
            /// Shop name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_carrier_create_update
        {
            [Newtonsoft.Json.JsonProperty("dummy_tr_generator", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Dummy_tr_generator { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_connector_create_details
        {
            /// <summary>
            /// Shop connector name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            /// <summary>
            /// Shop connector url.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Url { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_connector_response_details
        {
            [Newtonsoft.Json.JsonProperty("creation_date", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset Creation_date { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            /// <summary>
            /// Shop connector name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("updated_date", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset Updated_date { get; set; }

            /// <summary>
            /// Shop connector url.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Url { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_connector_shop_instance_configurations
        {
            [Newtonsoft.Json.JsonProperty("configuration_template", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<Configuration_template> Configuration_template { get; set; }

            [Newtonsoft.Json.JsonProperty("configurations", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<Configurations> Configurations { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_connector_update_details
        {
            /// <summary>
            /// Shop connector name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            /// <summary>
            /// Shop connector url.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Url { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_explode_bundles
        {
            [Newtonsoft.Json.JsonProperty("shop_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Shop_id { get; set; }

            [Newtonsoft.Json.JsonProperty("warehouse_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Warehouse_id { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_instance
        {
            [Newtonsoft.Json.JsonProperty("creation_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Creation_date { get; set; }

            /// <summary>
            /// Shop instance ID.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Id { get; set; }

            [Newtonsoft.Json.JsonProperty("is_dashboard_instance", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Is_dashboard_instance { get; set; }

            /// <summary>
            /// Shop instance name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("onboarding", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Onboarding { get; set; }

            /// <summary>
            /// False for instances where orders are manually created via Dashboard
            /// </summary>
            [Newtonsoft.Json.JsonProperty("requires_tracking_forwarding", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Requires_tracking_forwarding { get; set; }

            [Newtonsoft.Json.JsonProperty("shipment_option_rule", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Shipment_option_rule Shipment_option_rule { get; set; }

            [Newtonsoft.Json.JsonProperty("shop_connector", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Shop_connector Shop_connector { get; set; }

            [Newtonsoft.Json.JsonProperty("updated_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Updated_date { get; set; }

            [Newtonsoft.Json.JsonProperty("warehouse_assignment_strategy", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Warehouse_assignment_strategy Warehouse_assignment_strategy { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_instance_create_update
        {
            /// <summary>
            /// Shop instance ID.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Id { get; set; }

            [Newtonsoft.Json.JsonProperty("is_dashboard_instance", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Is_dashboard_instance { get; set; } = false;

            /// <summary>
            /// Shop instance name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("onboarding", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Onboarding { get; set; }

            /// <summary>
            /// False for instances where orders are manually created via Dashboard
            /// </summary>
            [Newtonsoft.Json.JsonProperty("requires_tracking_forwarding", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Requires_tracking_forwarding { get; set; }

            [Newtonsoft.Json.JsonProperty("shipment_option_rule_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Shipment_option_rule_id { get; set; }

            /// <summary>
            /// Shop connector id.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("shop_connector_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Shop_connector_id { get; set; }

            [Newtonsoft.Json.JsonProperty("warehouse_assignment_strategy_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Warehouse_assignment_strategy_id { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_instance_tokens
        {
            [Newtonsoft.Json.JsonProperty("connector_to_core_token", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Connector_to_core_token { get; set; }

            [Newtonsoft.Json.JsonProperty("core_to_connector_token", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Core_to_connector_token { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_payment_method_create_update
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_shipment_option_alias_create_update
        {
            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("shipment_option_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Shipment_option_id { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_shipment_option_create_update
        {
            [Newtonsoft.Json.JsonProperty("external_identifier", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string External_identifier { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Id { get; set; }

            [Newtonsoft.Json.JsonProperty("ignore", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool? Ignore { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_x_feature_flag
        {
            [Newtonsoft.Json.JsonProperty("feature_flag_owner", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Feature_flag_owner { get; set; }

            [Newtonsoft.Json.JsonProperty("feature_flags", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Feature_flag Feature_flags { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("is_active", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Is_active { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_x_feature_flag_update_request
        {
            [Newtonsoft.Json.JsonProperty("is_active", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Is_active { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_x_feature_flag_update_response
        {
            [Newtonsoft.Json.JsonProperty("feature_flag_owner", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Feature_flag_owner { get; set; }

            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("is_active", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Is_active { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_x_payment_method
        {
            [Newtonsoft.Json.JsonProperty("creation_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Creation_date { get; set; }

            /// <summary>
            /// Shop X Payment method ID.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("payment_method", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Payment_method2 Payment_method { get; set; }

            [Newtonsoft.Json.JsonProperty("updated_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Updated_date { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_x_payment_method_create_update
        {
            /// <summary>
            /// Shop X Payment method ID.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Id { get; set; }

            /// <summary>
            /// Payment method ID.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("payment_method_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Payment_method_id { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_x_warehouse
        {
            [Newtonsoft.Json.JsonProperty("creation_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Creation_date { get; set; }

            [Newtonsoft.Json.JsonProperty("shop_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Shop_id { get; set; }

            [Newtonsoft.Json.JsonProperty("updated_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Updated_date { get; set; }

            [Newtonsoft.Json.JsonProperty("warehouse_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Warehouse_id { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Stock_reservation_update
        {
            [Newtonsoft.Json.JsonProperty("fulfillment_item", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Fulfillment_item Fulfillment_item { get; set; }

            [Newtonsoft.Json.JsonProperty("order_number", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Order_number { get; set; }

            [Newtonsoft.Json.JsonProperty("quantity_reserved", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Quantity_reserved { get; set; }

            [Newtonsoft.Json.JsonProperty("reason_code", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Reason_code { get; set; }

            [Newtonsoft.Json.JsonProperty("stock", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Stock Stock { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Warehouse
        {
            [Newtonsoft.Json.JsonProperty("connector_to_core_token", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Connector_to_core_token { get; set; }

            /// <summary>
            /// Warehouse connector token.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("core_to_connector_token", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Core_to_connector_token { get; set; }

            [Newtonsoft.Json.JsonProperty("creation_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Creation_date { get; set; }

            [Newtonsoft.Json.JsonProperty("cut_off_time", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Cut_off_time { get; set; }

            [Newtonsoft.Json.JsonProperty("cut_off_type", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Cut_off_type { get; set; }

            [Newtonsoft.Json.JsonProperty("cut_off_window", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int Cut_off_window { get; set; }

            /// <summary>
            /// String choices are shipment_announcement and ship_all.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("empty_shipments_items_behavior", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Empty_shipments_items_behavior { get; set; }

            /// <summary>
            /// Warehouse ID.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Id { get; set; }

            /// <summary>
            /// Warehouse + Shop name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("internal_reference", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Internal_reference { get; set; }

            /// <summary>
            /// Warehouse name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("onboarding", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Onboarding { get; set; }

            [Newtonsoft.Json.JsonProperty("updated_date", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.DateTimeOffset? Updated_date { get; set; }

            /// <summary>
            /// Warehouse connector url.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("warehouse_connector_url", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Warehouse_connector_url { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Warehouse_create_update
        {
            /// <summary>
            /// Warehouse connector token.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("core_to_connector_token", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Core_to_connector_token { get; set; }

            [Newtonsoft.Json.JsonProperty("cut_off_time", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Cut_off_time { get; set; }

            [Newtonsoft.Json.JsonProperty("cut_off_type", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Cut_off_type { get; set; }

            [Newtonsoft.Json.JsonProperty("cut_off_window", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public int? Cut_off_window { get; set; }

            /// <summary>
            /// String choices are shipment_announcement and ship_all.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("empty_shipments_items_behavior", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Empty_shipments_items_behavior { get; set; }

            /// <summary>
            /// Warehouse ID.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Id { get; set; }

            /// <summary>
            /// Warehouse + Shop name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("internal_reference", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Internal_reference { get; set; }

            /// <summary>
            /// Warehouse name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("onboarding", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Onboarding { get; set; }

            /// <summary>
            /// Warehouse connector url.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("warehouse_connector_url", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Warehouse_connector_url { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum Stategroup
        {

            [System.Runtime.Serialization.EnumMember(Value = @"open")]
            Open = 0,

            [System.Runtime.Serialization.EnumMember(Value = @"closed")]
            Closed = 1,

            [System.Runtime.Serialization.EnumMember(Value = @"error")]
            Error = 2,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Body
        {
            [Newtonsoft.Json.JsonProperty("export_ids", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<System.Guid> Export_ids { get; set; }

            /// <summary>
            /// User id
            /// </summary>
            [Newtonsoft.Json.JsonProperty("resolved_by_user_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Resolved_by_user_id { get; set; }

            [Newtonsoft.Json.JsonProperty("resolved_comment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Resolved_comment { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Body2
        {
            [Newtonsoft.Json.JsonProperty("export_ids", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<System.Guid> Export_ids { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum Stategroup2
        {

            [System.Runtime.Serialization.EnumMember(Value = @"open")]
            Open = 0,

            [System.Runtime.Serialization.EnumMember(Value = @"closed")]
            Closed = 1,

            [System.Runtime.Serialization.EnumMember(Value = @"error")]
            Error = 2,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Body3
        {
            [Newtonsoft.Json.JsonProperty("import_ids", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<System.Guid> Import_ids { get; set; }

            /// <summary>
            /// User id
            /// </summary>
            [Newtonsoft.Json.JsonProperty("resolved_by_user_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Resolved_by_user_id { get; set; }

            [Newtonsoft.Json.JsonProperty("resolved_comment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Resolved_comment { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Body4
        {
            [Newtonsoft.Json.JsonProperty("import_ids", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<System.Guid> Import_ids { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum Fulfillment_state
        {

            [System.Runtime.Serialization.EnumMember(Value = @"new")]
            New = 0,

            [System.Runtime.Serialization.EnumMember(Value = @"warehouse_confirmation_pending")]
            Warehouse_confirmation_pending = 1,

            [System.Runtime.Serialization.EnumMember(Value = @"accepted_by_connector")]
            Accepted_by_connector = 2,

            [System.Runtime.Serialization.EnumMember(Value = @"accepted_by_warehouse")]
            Accepted_by_warehouse = 3,

            [System.Runtime.Serialization.EnumMember(Value = @"rejected_by_warehouse")]
            Rejected_by_warehouse = 4,

            [System.Runtime.Serialization.EnumMember(Value = @"in_fulfillment")]
            In_fulfillment = 5,

            [System.Runtime.Serialization.EnumMember(Value = @"partially_shipped")]
            Partially_shipped = 6,

            [System.Runtime.Serialization.EnumMember(Value = @"shipped")]
            Shipped = 7,

            [System.Runtime.Serialization.EnumMember(Value = @"canceled")]
            Canceled = 8,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum Fulfillment_stategroup
        {

            [System.Runtime.Serialization.EnumMember(Value = @"open")]
            Open = 0,

            [System.Runtime.Serialization.EnumMember(Value = @"canceled")]
            Canceled = 1,

            [System.Runtime.Serialization.EnumMember(Value = @"completed")]
            Completed = 2,

            [System.Runtime.Serialization.EnumMember(Value = @"all")]
            All = 3,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum Stategroup3
        {

            [System.Runtime.Serialization.EnumMember(Value = @"open")]
            Open = 0,

            [System.Runtime.Serialization.EnumMember(Value = @"closed")]
            Closed = 1,

            [System.Runtime.Serialization.EnumMember(Value = @"requires_attention")]
            Requires_attention = 2,

            [System.Runtime.Serialization.EnumMember(Value = @"all")]
            All = 3,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public enum Cancellation_state
        {

            [System.Runtime.Serialization.EnumMember(Value = @"new")]
            New = 0,

            [System.Runtime.Serialization.EnumMember(Value = @"rejected")]
            Rejected = 1,

            [System.Runtime.Serialization.EnumMember(Value = @"connector_confirmation_pending")]
            Connector_confirmation_pending = 2,

            [System.Runtime.Serialization.EnumMember(Value = @"accepted_by_connector")]
            Accepted_by_connector = 3,

            [System.Runtime.Serialization.EnumMember(Value = @"warehouse_cancellation_pending")]
            Warehouse_cancellation_pending = 4,

            [System.Runtime.Serialization.EnumMember(Value = @"completed")]
            Completed = 5,

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Body5
        {
            [Newtonsoft.Json.JsonProperty("carrier_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Carrier_id { get; set; }

            [Newtonsoft.Json.JsonProperty("tracking_codes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<string> Tracking_codes { get; set; }

            [Newtonsoft.Json.JsonProperty("tracking_urls", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<string> Tracking_urls { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Response
        {
            [Newtonsoft.Json.JsonProperty("failed", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<Export_http> Failed { get; set; }

            [Newtonsoft.Json.JsonProperty("resolved", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<Export_http> Resolved { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Response2
        {
            [Newtonsoft.Json.JsonProperty("failed", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<Export_http> Failed { get; set; }

            [Newtonsoft.Json.JsonProperty("reexported", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<Export_http> Reexported { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Response3
        {
            [Newtonsoft.Json.JsonProperty("failed", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<Import> Failed { get; set; }

            [Newtonsoft.Json.JsonProperty("resolved", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<Import> Resolved { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Response4
        {
            [Newtonsoft.Json.JsonProperty("failed", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<Import> Failed { get; set; }

            [Newtonsoft.Json.JsonProperty("reimported", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<Import> Reimported { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop2
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Acknowledged_by
        {
            /// <summary>
            /// User email.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Email { get; set; }

            /// <summary>
            /// User first name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("first_name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string First_name { get; set; }

            /// <summary>
            /// User id.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            /// <summary>
            /// User last name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("last_name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Last_name { get; set; }

            /// <summary>
            /// User phone.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("phone", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Phone { get; set; }

            /// <summary>
            /// User status.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Status { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop3
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Image_urls
        {
            [Newtonsoft.Json.JsonProperty("default", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Default { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Url { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Image_urls2
        {
            [Newtonsoft.Json.JsonProperty("default", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Default { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Url { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shipment_option_aliases
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop4
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shipment_option2
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("shop_id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid? Shop_id { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop5
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shipment_option3
        {
            /// <summary>
            /// Shipment option id.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            /// <summary>
            /// Shipment option ignored flag.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("ignored", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Ignored { get; set; }

            /// <summary>
            /// Shipment option name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("shipment_option_aliases", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<object> Shipment_option_aliases { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Warehouse2
        {
            /// <summary>
            /// Warehouse id.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            /// <summary>
            /// Warehouse + Shop name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("internal_reference", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Internal_reference { get; set; }

            /// <summary>
            /// Warehouse name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Configuration_template
        {
            [Newtonsoft.Json.JsonProperty("configuration_name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Configuration_name { get; set; }

            [Newtonsoft.Json.JsonProperty("default", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Default { get; set; }

            [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Description { get; set; }

            [Newtonsoft.Json.JsonProperty("example", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Example { get; set; }

            [Newtonsoft.Json.JsonProperty("item_type", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Item_type { get; set; }

            [Newtonsoft.Json.JsonProperty("required", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public bool Required { get; set; }

            [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Type { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Configurations
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("properties", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Collections.Generic.List<Properties> Properties { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shipment_option_rule
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Shop_connector
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Url { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Warehouse_assignment_strategy
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Payment_method2
        {
            /// <summary>
            /// Payment method id.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            /// <summary>
            /// Payment method name.
            /// </summary>
            [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Name { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Fulfillment_item
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Id { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Stock
        {
            [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public System.Guid Id { get; set; }

            [Newtonsoft.Json.JsonProperty("product", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public Product2 Product { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Properties
        {
            [Newtonsoft.Json.JsonProperty("configuration_name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Configuration_name { get; set; }

            [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Value { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }

        [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
        public partial class Product2
        {
            [Newtonsoft.Json.JsonProperty("sku", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public string Sku { get; set; }

            private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

            [Newtonsoft.Json.JsonExtensionData]
            public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
            {
                get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
                set { _additionalProperties = value; }
            }

        }


    }
}
