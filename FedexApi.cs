using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Fedex
{
    public class FedexApi
    {
        internal static async Task<string> GetAccessTokenAsync()
            {
                var tokenAndExp = await GenToken();
                var tokenTo = int.Parse(tokenAndExp["expires_in"]);
                if (tokenTo <= 50)
                {
                        tokenAndExp = await GenToken();
                }
                return tokenAndExp["access_token"];
            }

            private static async Task<Dictionary<string,string>> GenToken()
            {
                var client = new RestClient(Program.Config("baseUrl").ToString().Trim());
                var request = new RestRequest($"{Program.Config("baseUrl")}", Method.Post);
                request.AddHeader( "Content-Type","application/x-www-form-urlencoded");
                request.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials&client_id={Program.Config("tok")}&client_secret={Program.Config("sec")}",ParameterType.RequestBody);
                try
                {
                    return await ResponseObject(client, request);
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("500") || e.Message.Contains("503"))
                    {
                        await Task.Delay(3000);
                        return await ResponseObject(client, request);
                    }
                    Console.WriteLine(e);
                    throw;
                } 
            }

            private static async Task<Dictionary<string, string>> ResponseObject(IRestClient client, RestRequest request)
            {
                var response = await client.ExecuteAsync(request);
                var content = response.Content;
                var responseObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(content ?? throw new InvalidOperationException());
                return responseObject;
            }
    }
}