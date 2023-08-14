using System;
using RestSharp;
using sunguIntegration.Dal;

namespace sunguIntegration.Service
{
	public class GeneralRestService
	{
        public async Task<RestResponse> Post(string url, object? bodyObject = null)
        {

            var client = new RestClient(new RestClientOptions());
            var request = new RestRequest(url, Method.Post);

            if (bodyObject != null)
            {
                request.AddBody(bodyObject);
            }
            RestResponse response = await client.ExecuteAsync(request);

            return response;
        }
    }
}

