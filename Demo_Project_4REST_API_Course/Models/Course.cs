using Demo_Project_4REST_API_Course.Infrastructure;
namespace Demo_Project_4REST_API_Course.Models
{
    public class Course : Resource
    {
        public int Id { get; set; }
        [Sortable]
        public string Codigo { get; set; }
        [Sortable(Default = true)]
        public string Nombre { get; set; }
        [Sortable]
        public int Creditos { get; set; }
        [Sortable]
        public double Promedio { get; set; }
        public int IdCiclo { get; set; }
    }
}
