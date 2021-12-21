using System.ComponentModel.DataAnnotations;

namespace Demo_Project_4REST_API_Course.Models
{
    public class CourseForm
    {
        [Required]
        [Display(Name = "Codigo", Description = "Codigo del curso")]
        public string Codigo { get; set; }
        [Required]
        [Display(Name = "Nombre", Description = "Nombre del curso")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Creditos", Description = "Creditos del curso")]
        public int Creditos { get; set; }
        [Required]
        [Display(Name = "IdCiclo", Description = "Ciclo al que pertenece el curso")]
        public int IdCiclo { get; set; }
    }
}
