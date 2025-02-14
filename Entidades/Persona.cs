namespace Entidades
{
    public class Persona
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        // Considera agregar más propiedades según los requisitos del sistema

        // Relaciones (si aplicable)
        public virtual List<Tarjeta> Tarjetas { get; set; } = new List<Tarjeta>();
    }

}