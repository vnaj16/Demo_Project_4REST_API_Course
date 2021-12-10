using Demo_Project_4REST_API_Course.Infrastructure;

namespace Demo_Project_4REST_API_Course.Models
{
    public class Cycle : Resource
    {
        public int Id { get; set; }
        [Sortable]
        public string Codigo { get; set; }
        [Sortable]
        public double Promedio { get; set; }
    }
}
