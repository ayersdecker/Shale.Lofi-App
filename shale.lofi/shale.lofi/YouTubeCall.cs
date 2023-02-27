using CommunityToolkit.Maui.Views;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shale.lofi
{
    class YouTubeCall
    {

        public string apiKey = "AIzaSyAnBhIP9Dp9WzorlS_NlocBiLB_DGKNjYA";
        private string apiURL = "https://www.googleapis.com/youtube/v3/search?part=snippet&maxResults=25&q=lofi&type=video&key=";

        private async Task<string> GetVideoId()
        {
            string videoId = "";
            string url = apiURL + apiKey;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(content);
                var items = json["items"];
                var firstItem = items.First;
                var id = firstItem["id"];
                videoId = id["videoId"].ToString();
            }
            return videoId;
        }

        public static void SetSource(ref MediaElement element)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyAnBhIP9Dp9WzorlS_NlocBiLB_DGKNjYA"
            });

            var videoRequest = youtubeService.Videos.List("snippet, contentDetails");
            videoRequest.Id = "n61ULEU7CO0";

            var videoResponse = videoRequest.ExecuteAsync();
            var video = videoResponse.Result.Items.FirstOrDefault();

            if (video != null)
            {
                // Get the YouTube video URL from the video details
                var videoUrl = $"https://www.youtube.com/watch?v={video.Id}";

                // Set the Source property of the MediaElement to the video URL
                element.Source = new Uri(videoUrl);
            }

        }





    }
}
