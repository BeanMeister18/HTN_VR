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










//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Linq;
//using System.Net.Http;
//using Newtonsoft.Json.Linq;
//using System.Threading.Tasks;


//public class ProductScraper : MonoBehaviour
//{
//    private static readonly string shopifyUrl = "https://quickstart-18bf5f9b.myshopify.com";
//    private static readonly string accessToken = "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";

//    // Start is called before the first frame update
//    void Start()
//    {
//        // Start the coroutine to fetch the products
//        StartCoroutine(FetchProducts());
//    }

//    // Coroutine to handle async behavior in Unity
//    private IEnumerator FetchProducts()
//    {
//        string endpoint = "/admin/api/2024-07/product_listings.json"; // Shopify API endpoint for products
//        using (HttpClient client = new HttpClient())
//        {
//            // Shopify requires Basic Authentication (Base64 encoded)
//            client.BaseAddress = new Uri(shopifyUrl);
//            client.DefaultRequestHeaders.Add("X-Shopify-Access-Token", accessToken);

//            try
//            {
//                Task<HttpResponseMessage> responseTask = client.GetAsync(endpoint);
//                return new WaitUntil(() => responseTask.IsCompleted); // Wait for the async task to complete

//                HttpResponseMessage response = responseTask.Result;
//                response.EnsureSuccessStatusCode(); // Throw if not a success code.

//                Task<string> responseBodyTask = response.Content.ReadAsStringAsync();
//                return new WaitUntil(() => responseBodyTask.IsCompleted); // Wait for the content to be read

//                string responseBody = responseBodyTask.Result;

//                JObject data = JObject.Parse(responseBody);

//                // Create an array to hold the extracted data
//                int productCount = data["product_listings"].Count();
//                object[] productsArray = new object[productCount];

//                int index = 0;
//                foreach (var product in data["product_listings"])
//                {
//                    // Extract values
//                    long productId = (long)product["product_id"];
//                    string title = (string)product["title"];
//                    string price = (string)product["variants"][0]["price"];
//                    string imageUrl = (string)product["images"][0]["src"];

//                    // Store the extracted values in the array
//                    productsArray[index] = new { productId, title, price, imageUrl };
//                    index++;
//                }

//                // Output the array data using Unity's logging system
//                foreach (var product in productsArray)
//                {
//                    Debug.Log(product);
//                }
//            }
//            catch (HttpRequestException e)
//            {
//                Debug.LogError("Request error: " + e.Message);
//            }
//        }
//    }


//}












//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;
//using System.Net.Http;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;



//public class ProductScraper : MonoBehaviour
//{
//    // Create an array to hold the extracted data
//    int productCount = data["product_listings"].Count();
//    object[] productsArray = new object[productCount];

//    // Start is called before the first frame update
//    void Start()
//    {
//        private static readonly string shopifyUrl = "https://quickstart-18bf5f9b.myshopify.com";

//        private static readonly string accessToken = "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";
//        await FetchProducts();

//        static async Task FetchProducts()
//        {
//            string endpoint = "/admin/api/2024-07/product_listings.json"; // Shopify API endpoint for products
//            using (HttpClient client = new HttpClient())
//            {
//                // Shopify requires Basic Authentication (Base64 encoded)
//                client.BaseAddress = new Uri(shopifyUrl);
//                try
//                {
//                    client.DefaultRequestHeaders.Add("X-Shopify-Access-Token", accessToken);
//                    HttpResponseMessage response = await client.GetAsync(endpoint);
//                    response.EnsureSuccessStatusCode(); // Throw if not a success code.
//                    string responseBody = await response.Content.ReadAsStringAsync();

//                    JObject data = JObject.Parse(responseBody);

//                    int index = 0;
//                    foreach (var product in data["product_listings"])
//                    {
//                        // Extract values
//                        long productId = (long)product["product_id"];
//                        string title = (string)product["title"];
//                        string price = (string)product["variants"][0]["price"];
//                        string imageUrl = (string)product["images"][0]["src"];

//                        // Store the extracted values in the array (sent to Unity)
//                        productsArray[index] = new { productId, title, price, imageUrl };
//                        index++;
//                    }

//                    // Output the array data
//                    foreach (var product in productsArray)
//                    {
//                        Console.WriteLine(product);
//                    }

//                }
//                catch (HttpRequestException e)
//                {
//                    Console.WriteLine("Request error: " + e.Message);
//                }
//            }
//        }
//}



//    // Update is called once per frame
//    //void Update()
//    //{

//    //}

