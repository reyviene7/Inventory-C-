using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ServeAll.Core.Repository
{
    public class AiService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<List<decimal>> GetPricingSuggestions(string productDescription)
        {
            const string apiUrl = "https://api.openai.com/v1/engines/davinci/completions"; // Update this with your actual API endpoint
            const string apiKey = @"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";

            var requestContent = new StringContent(
                "{\"prompt\": \"" + productDescription + "\", \"max_tokens\": 60}",
                Encoding.UTF8,
                "application/json");

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

            var response = await httpClient.PostAsync(apiUrl, requestContent);
            var responseString = await response.Content.ReadAsStringAsync();

            // Parse the response to get pricing suggestions
            var priceSuggestions = ParsePricingSuggestions(responseString);
            priceSuggestions.Sort((x, y) => y.CompareTo(x)); // Sort by highest price

            return priceSuggestions;
        }

        private static List<decimal> ParsePricingSuggestions(string responseString)
        {
            var prices = new List<decimal>();

            // Assuming the API returns a JSON object with a list of prices in the completion's text field
            var json = JObject.Parse(responseString);
            var text = json["choices"]?[0]?["text"]?.ToString();

            // Parse the prices from the text
            var priceStrings = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            foreach (var price in priceStrings)
            {
                if (decimal.TryParse(price, out decimal parsedPrice))
                {
                    prices.Add(parsedPrice);
                }
            }
            return prices;
        }
    }
}