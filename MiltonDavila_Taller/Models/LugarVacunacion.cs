namespace MiltonDavila_Taller.Models
{
    public class LugarVacunacion
    {
        public int Id { get; set; }
        public required DateTime FechaVacunacion { get; set; }
        public required string Direccion { get; set; }

        public required string Ciudad { get; set; }
    }
}
