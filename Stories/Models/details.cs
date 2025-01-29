using System.Text.Json.Serialization;

namespace Stories.Models
{
    public class details
    {

        public string Title { get; set; } = "Unknown";
        public string Url { get; set; } = "Unknown";
        public string By { get; set; } = "Unknown";
        [JsonConverter(typeof(DateTimeConverter))]
        public long Time { get; set; }
        public int Score { get; set; }

    }
}
