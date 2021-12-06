using System.Collections.Generic;

namespace Demo_Project_4REST_API_Course.Models
{
    public class CycleEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public double Promedio { get; set; }
        public List<CourseEntity> Cursos { get; set; }
    }
}
