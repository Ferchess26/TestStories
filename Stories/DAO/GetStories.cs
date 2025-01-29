using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using Stories.Models;

namespace Stories.DAO
{
    public class GetStories
    {
        public async Task Stories()
        {
            try
            {
                List<int> lsStories = await GetIdStories();

                if (lsStories.Count > 0 && lsStories != null)
                {
                    List<details> lsDetails = await GetDetails(lsStories);

                    Services.DetailsCache.Details = lsDetails;
                }
            }
            catch {}
 
        }

        static async Task<List<int>> GetIdStories()
        {
            string url = "https://hacker-news.firebaseio.com/v0/beststories.json";
            using HttpClient client = new();

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<int>>(json) ?? new List<int>();
            }
            catch (Exception)
            {
                return new List<int>();
            }
        }

        static async Task<List<details>> GetDetails(List<int> lsStories)
        {
            List<details> lsDetails = new();
            using HttpClient client = new();

            string detUrl = "https://hacker-news.firebaseio.com/v0/item/";

            var tasks = lsStories.Select(async id =>
            {
                try
                {
                    string url = $"{detUrl}{id}.json";
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    details ? story = JsonSerializer.Deserialize<details>(json, options);

                    if (story != null)
                    {
                        lock (lsDetails)
                        {
                            lsDetails.Add(story);
                        }
                    }
                }
                catch{}
            }).ToList();

            await Task.WhenAll(tasks);

            return lsDetails.OrderByDescending(h => h.Score).ToList();
        }
    }

}
