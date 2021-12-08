using Newtonsoft.Json;
using System.ComponentModel;

namespace Demo_Project_4REST_API_Course.Models
{
    public class Link
    {
        [JsonProperty(Order =-4)]
        public string Href { get; set; }

        [JsonProperty(Order = -3,PropertyName ="rel",NullValueHandling = NullValueHandling.Ignore)]
        public string[] Relations { get; set; }

        [JsonProperty(Order = -2
            , DefaultValueHandling=DefaultValueHandling.Ignore
            , NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue("GET")]
        public string Method { get; set; }

        //Stores the route name before being rewritten by the LinkRewritingFilter
        [JsonIgnore]
        public string RouteName { get; set; }

        //Stores the route parameters before being rewritten by the LinkRewritingFilter
        [JsonIgnore]
        public object RouteValues { get; set; }

        public static Link To(string routeName, object routeValues = null)
            => new Link
            {
                RouteName = routeName,
                RouteValues = routeValues,
                Method = "GET",
                Relations = null
            };


        public static Link ToCollection(string routeName, object routeValues = null)
            => new Link
            {
                RouteName = routeName,
                RouteValues = routeValues,
                Method = "GET",
                Relations = new[] { "collection" }
            };
    }
}
