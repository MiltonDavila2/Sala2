using System.ComponentModel.DataAnnotations;

namespace MiltonDavila_Taller.Models
{
    public class EstudianteUDLA
    {
        [Key]
        public required int BannerID { get; set; }

        public string NombreEstudiante { get; set; }


        public DateTime? FechadeNacimiento { get; set; }

        public LugarVacunacion LugarVacunacion { get; set; }

        public Vacuna Vacuna { get; set; }


    }
}
