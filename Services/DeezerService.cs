using Newtonsoft.Json.Linq;
using SpotifyMoodAPI.Models;

namespace SpotifyMoodAPI.Services
{
    public class DeezerService
    {
        private readonly HttpClient _http;

        public DeezerService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient();
        }

        private string MapMoodToKeyword(string mood) => mood.ToLower() switch
        {
            "happy"     => "happy pop",
            "sad"       => "sad acoustic",
            "angry"     => "heavy metal",
            "chill"     => "lofi chill",
            "romantic"  => "romantic love",
            "focus"     => "instrumental study",
            "energetic" => "edm workout",
            _           => "pop hits"
        };

        public async Task<List<TrackResult>> GetTracksByMoodAsync(string mood, int limit = 10)
        {
            var keyword = MapMoodToKeyword(mood);
            var url = $"https://api.deezer.com/search?q={Uri.EscapeDataString(keyword)}&limit={limit}";

            var response = await _http.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            Console.WriteLine("=== DEEZER RESPONSE ===");
            Console.WriteLine($"Status: {response.StatusCode}");
            Console.WriteLine("=======================");

            if (!response.IsSuccessStatusCode)
                return new List<TrackResult>();

            var data = JObject.Parse(json);
            var items = data["data"] as JArray;
            var tracks = new List<TrackResult>();

            if (items == null) return tracks;

            foreach (var item in items)
            {
                tracks.Add(new TrackResult
                {
                    TrackName  = item["title"]?.ToString(),
                    Artist     = item["artist"]?["name"]?.ToString(),
                    Album      = item["album"]?["title"]?.ToString(),
                    PreviewUrl = item["preview"]?.ToString(),
                    SpotifyUrl = item["link"]?.ToString()
                });
            }

            return tracks;
        }
    }
}