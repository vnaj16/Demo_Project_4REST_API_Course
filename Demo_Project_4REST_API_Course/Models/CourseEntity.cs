namespace Demo_Project_4REST_API_Course.Models
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public double Promedio { get; set; }
        public int IdCiclo { get; set; }
        public CycleEntity Ciclo { get; set; }

    }
}
