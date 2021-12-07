using Newtonsoft.Json;

namespace Demo_Project_4REST_API_Course.Models
{
    public abstract class Resource : Link
    {
        [JsonIgnore]
        public Link Self { get; set; }
    }
}
