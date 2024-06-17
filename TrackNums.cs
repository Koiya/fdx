using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Fedex
{
    public class TrackNums
    { 
        public static async Task<List<CompleteTrackResult>> GetTrack(string token)
        {
            var client = new RestClient($"{Program.Config("fetch")}".Trim());
            var request = new RestRequest($"{Program.Config("fetch")}".Trim(), Method.Post);
            var tn = new {trackingNumber = $"{Program.Config("id")}".Trim()};
            var tni = new {trackingNumberInfo = tn};
            object[] tnio = { tni };
            var ti = new { trackingInfo = tnio };
            var createJson = JsonConvert.SerializeObject(ti);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddHeader("X-locale", "en_US");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/x-www-form-urlencoded",createJson, ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);
            var content = response.Content;
            var responseObject = JsonConvert.DeserializeObject<TrackResponse>(content ?? throw new InvalidOperationException());//(JObject)JsonConvert.DeserializeObject(content ?? string.Empty);
            var data = responseObject.Output.CompleteTrackResults; //responseObject?["output"]["completeTrackResults"][0];
            //Console.WriteLine(data);
            return data;
        }
    }
}