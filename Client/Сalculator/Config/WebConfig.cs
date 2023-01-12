using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Сalculator.Models;

namespace Сalculator.Config
{
    internal static class WebConfig
    {
        internal static HttpClient client = new HttpClient();

        internal static void RegisterClient()
        {
            client.BaseAddress = new Uri("https://localhost:7152/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        internal static async Task<string> GetValueResult(string a, string b, string path)
        {
            string result = "";
            ValueModel valueModel = new ValueModel() { ValueA = a, ValueB = b };
            string jsonString = JsonSerializer.Serialize(valueModel);
            HttpResponseMessage response = await client.PostAsJsonAsync(path, valueModel);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<string>();
            }
            return result;
        }

    }
}
