using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UploadTracking.Models.ThirdPartyModels.Shopify
{
    public class ShopifyOrders
    {
        [JsonProperty("orders")]
        public List<ShopifyOrder> Order { get; set; }
    }

    public class ShopifyOrder
    {
        [JsonProperty("id")]
        public string ShopifyOrderId { get; set; }
        [JsonProperty("name")]
        public string StoreOrderId { get; set; }
        [JsonProperty("email")]
        public string CustomerEmail { get; set; }

        [JsonProperty("line_items")]
        public List<LineItems> LineItems { get; set; }

        //[JsonProperty("email")]
        //public List<Fulfillments> Fulfillments { get; set;}
    }

    public class LineItems
    {
        [JsonProperty("id")]
        public string ItemId { get; set; }

        [JsonProperty("email")]
        public string VariantId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("fulfillable_quantity")]
        public int FulfillableQty { get; set; }
    }

    public class Fulfillments
    {
        [JsonProperty("id")]
        public int FulfillmentId { get; set; }
        public int MyProperty { get; set; }

    }
}
