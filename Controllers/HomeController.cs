using BusinessNewsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using BusinessNewsApp.Models;

namespace BusinessNewsApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            // 1. Set up the API details
            string apiKey = "712aad9a38f6483a89958b25e51dcbf8";
            string url = $"https://newsapi.org/v2/top-headlines?country=us&category=business&apiKey={apiKey}";

            using (var client = new HttpClient())
            {
                // 2. Add a User-Agent header (required by NewsAPI)
                client.DefaultRequestHeaders.Add("User-Agent", "BusinessNewsApp");

                // 3. Make the request
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // 4. Read the JSON string
                    var json = await response.Content.ReadAsStringAsync();

                    // 5. Convert JSON string into C# objects
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var newsData = JsonSerializer.Deserialize<NewsResponse>(json, options);

                    // 6. Pass the list of articles to the View
                    return View(newsData.Articles);
                }
            }

            // Return an empty list if the API call fails
            return View(new List<Article>());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
