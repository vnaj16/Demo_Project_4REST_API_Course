namespace Demo_Project_4REST_API_Course.Models
{
    public class Collection<T> : Resource
    {
        public T[] Value { get; set; }
    }
}
