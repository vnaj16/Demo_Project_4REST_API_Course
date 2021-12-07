namespace Demo_Project_4REST_API_Course.Models
{
    public class RootResponse : Resource
    {
        public Link Courses { get; set; }
        public Link Cycles { get; set; }
    }
}
