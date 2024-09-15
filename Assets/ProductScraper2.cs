using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ProductScraper : MonoBehaviour
{
    private static readonly string shopifyUrl = "https://quickstart-18bf5f9b.myshopify.com";
    private static readonly string accessToken = "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";

    // Create an array to hold the extracted data
    int productCount;
    object[] productsArray;

    // Start is called before the first frame update
    async void Start()
    {
        await FetchProducts();
    }

    private async Task FetchProducts()
    {
        string endpoint = "/admin/api/2024-07/product_listings.json"; // Shopify API endpoint for products
        using (HttpClient client = new HttpClient())
        {
            // Shopify requires Basic Authentication (Base64 encoded)
            client.BaseAddress = new Uri(shopifyUrl);
            client.DefaultRequestHeaders.Add("X-Shopify-Access-Token", accessToken);
            try
            {
                HttpResponseMessage response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode(); // Throw if not a success code.

                string responseBody = await response.Content.ReadAsStringAsync();
                JObject data = JObject.Parse(responseBody);

                // Create an array to hold the extracted data
                int productCount = data["product_listings"].Count();
                productsArray = new object[productCount];

                int index = 0;
                foreach (var product in data["product_listings"])
                {
                    long productId = (long)product["product_id"];
                    string title = (string)product["title"];
                    string price = (string)product["variants"][0]["price"];
                    string imageUrl = (string)product["images"][0]["src"];

                    productsArray[index] = new { productId, title, price, imageUrl };
                    index++;
                }

                // Output the array data
                foreach (var product in productsArray)
                {
                    Debug.Log(product);
                }
            }
            catch (HttpRequestException e)
            {
                Debug.LogError("Request error: " + e.Message);
            }
        }
    }
}

