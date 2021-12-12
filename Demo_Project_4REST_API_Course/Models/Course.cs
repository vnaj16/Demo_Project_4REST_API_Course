using Demo_Project_4REST_API_Course.Infrastructure;
namespace Demo_Project_4REST_API_Course.Models
{
    public class Course : Resource
    {
        public int Id { get; set; }
        [Sortable]
        [Searchable]
        public string Codigo { get; set; }
        [Sortable(Default = true)]
        [Searchable]
        public string Nombre { get; set; }
        [Sortable]
        [SearchableInt]
        public int Creditos { get; set; }
        [Sortable]
        [Searchable]
        public double Promedio { get; set; }
        public int IdCiclo { get; set; }
    }
}
