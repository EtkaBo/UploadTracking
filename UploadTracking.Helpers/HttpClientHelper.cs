using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UploadTracking.Models.ThirdPartyModels.Shopify;
using UploadTracking.Models.UploadTrackingApiModels;

namespace UploadTracking.Helpers
{
    public static class HttpClientHelper
    {
        //public static async Task<T> Get<T>(UploadTrackingApiRequest request)
        //{
        //    try
        //    {
        //        HttpResponseMessage response;
        //        using (var http = new HttpClient())
        //        {
        //            string queryString = "?";

        //            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            if (request.Header != null)
        //            {
        //                foreach (var header in request.Header)
        //                {
        //                    http.DefaultRequestHeaders.Add(header.Key, header.Value);
        //                }
        //            }

        //            if (request.QueryString != null)
        //            {
        //                foreach (var qString in request.QueryString)
        //                {
        //                    queryString += qString.Key + "=" + qString.Value + "&";
        //                }
        //            }

        //            response = await http.GetAsync(request.Url + queryString);
        //        }
        //        return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static async Task<UploadTrackingApiResponse<T>> Get<T>(UploadTrackingApiRequest request)
        {
            UploadTrackingApiResponse<T> response = new UploadTrackingApiResponse<T>();

            try
            {
                using (var http = new HttpClient())
                {
                    string queryString = "?";

                    http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (request.Header != null)
                    {
                        foreach (var header in request.Header)
                        {
                            http.DefaultRequestHeaders.Add(header.Key, header.Value);
                        }
                    }

                    if (request.QueryString != null)
                    {
                        foreach (var qString in request.QueryString)
                        {
                            queryString += qString.Key + "=" + qString.Value + "&";
                        }
                    }

                    var result = await http.GetAsync(request.Url + queryString);
                    try
                    {
                        T data = JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());

                        response.Data = data;
                        response.StatusCode = result.StatusCode;
                        response.ErrorMessage = result.ReasonPhrase;
                    }
                    catch (Exception ex)
                    {
                    }

                    //result.RequestMessage = response.ErrorMessage;

                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<UploadTrackingApiResponse<T>> Post<T, D>(UploadTrackingApiUpsertRequest<D> request)
        {
            try
            {
                HttpResponseMessage response;
                using (var http = new HttpClient())
                {
                    http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (request.Header != null)
                    {
                        foreach (var header in request.Header)
                        {
                            http.DefaultRequestHeaders.Add(header.Key, header.Value);
                        }
                    }

                    var json = JsonConvert.SerializeObject(request.Data);
                    StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    response = await http.PostAsync(request.Url, stringContent);
                }
                return new UploadTrackingApiResponse<T>
                {
                    Data = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync()),
                    StatusCode = response.StatusCode,
                    ErrorMessage = response.RequestMessage.ToString()
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
