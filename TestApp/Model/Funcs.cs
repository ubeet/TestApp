using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestApp.Model
{
    class Funcs
    {
        private static readonly string apiKey = "083f774c-a2f8-4996-9452-1a50f4f2eaf0";

        public static async Task<ObservableCollection<Cryptocurrency>> GetCryptoDataAsync()
        {
            var newData = new ObservableCollection<Cryptocurrency>();
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("api-key", apiKey);
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.coincap.io/v2/assets");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var jsonDataSets = Regex.Matches(result.Substring(1), @"{(.*?)}");

            foreach(Match jsonDataSet in jsonDataSets)
            {
                var dataSet = JsonConvert.DeserializeObject<JToken>(jsonDataSet.Value);
                var sda = dataSet["marketCapUsd"];
                newData.Add(new Cryptocurrency(dataSet["id"].ToString(), Convert.ToInt32(dataSet["rank"]), 
                    dataSet["symbol"].ToString(), dataSet["name"].ToString(), Convert.ToDouble(dataSet["marketCapUsd"]), 
                    Convert.ToDouble(dataSet["volumeUsd24Hr"]), Convert.ToDouble(dataSet["priceUsd"]), 
                    Convert.ToDouble(dataSet["changePercent24Hr"])));
            }
            return newData;
        }
    }
}
