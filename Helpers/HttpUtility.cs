using RestSharp;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System;

namespace WordlersWeb.Helpers
{
    public static class HttpUtility
    {
        public static async Task<RestResponse> MakePost(string endpoint, object requestObject, Dictionary<string, string> headers)
        {
            using(var client = new RestClient(options: HttpHandler()))
            {
                try
                {
                    var request = new RestRequest(endpoint, Method.Post);
                    if (headers != null)
                        foreach (var header in headers)
                            request.AddHeader(header.Key, header.Value);
                    if (requestObject != null)
                        request.AddJsonBody(requestObject);
                    return await client.ExecuteAsync(request);
                }
                catch (Exception ex)
                {
                    return default(RestResponse);
                }
            }
        }

        public static async Task<RestResponse> MakeGet(string endpoint, Dictionary<string, string> requestParams, Dictionary<string, string> headers)
        {
            using (var client = new RestClient(options: HttpHandler()))
            {
                try
                {
                    var request = new RestRequest(endpoint, Method.Get);
                    if (headers != null)
                        foreach (var header in headers)
                            request.AddHeader(header.Key, header.Value);
                    if (requestParams != null)
                        foreach (var param in requestParams)
                            request.AddParameter(param.Key, param.Value);
                    return await client.ExecuteAsync(request);
                }
                catch (Exception ex)
                {
                    return default(RestResponse);
                }
            }
        }

        private static RestClientOptions HttpHandler() => new RestClientOptions { RemoteCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true };
    }
}
