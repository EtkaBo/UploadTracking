using System;
using System.Collections.Generic;
using System.Text;

namespace UploadTracking.Models.Constants
{
    public static class ShopifyConstants
    {

        //TODO: get apikey and apisecret from app config
       public const string apiKey = "";
       public const string apiSecretKey = "";
       public const string scopes = "read_orders,write_orders";
       public const string redirectUri = "http://localhost:56754/api/shopify/IntegrateShopifyCallback";
    }
}
