using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShortUrlApiTests
{
    public class ShortUrl
    {
        [JsonPropertyName("url")]
        public string url { get; set; }
       public string shortCode { get; set; }
        public string shortUrl { get; set; }
       // public string dateCreated { get; set; } 
        //public string visits { get; set; }
        
    }
}
