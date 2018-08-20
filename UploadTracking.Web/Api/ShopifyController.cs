using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadTracking.BLL.Interfaces;
using UploadTracking.Models.UploadTrackingApiModels;

namespace UploadTracking.Web.Api
{
    [AllowAnonymous]
    [Route("api/Shopify")]
    public class ShopifyController : Controller
    {
        private readonly IShopifyBLL _shopifyBLL;

        public ShopifyController(IShopifyBLL shopifyBLL)
        {
            _shopifyBLL = shopifyBLL;
        }

        [Route("IntegrateShopify")]
        public async Task<IActionResult> IntegrateShopify()
        {
            var result = await _shopifyBLL.IntegrateShopify(34);

            return Redirect(result.Url + result.QueryString);
        }

        [Route("IntegrateShopifyCallback")]
        public async Task<IActionResult> IntegrateCallback(string code, string hmac, string shop, string timestamp)
        {
            await _shopifyBLL.GetAccessToken(code, shop);
            return Ok();
        }

        [Route("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _shopifyBLL.GetOrders(123);
            return Ok(result.Data);
        }

        //public async Task<IActionResult> UploadTracking()
        //{
        //    _shopifyBLL.CreateFulfillment();
        //}

        public IActionResult HandleStatusCode<T>(HttpStatusCode statusCode, UploadTrackingApiResponse<T> response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
                return Ok(response.Data);

            else if (statusCode == HttpStatusCode.NotFound)
                return NotFound();

            else if (statusCode == HttpStatusCode.Accepted)
                return Accepted(response.Data);

            else if (statusCode == HttpStatusCode.BadRequest)
                return BadRequest(response.ErrorMessage);

            return Ok();

        }
    }
}
