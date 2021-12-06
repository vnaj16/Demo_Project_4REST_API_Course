using Newtonsoft.Json;

namespace Demo_Project_4REST_API_Course.Models
{
    public abstract class Resource
    {
        [JsonProperty(Order =-2)]
        public string Href { get; set; }
    }
}
