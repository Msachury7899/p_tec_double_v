namespace Double.V.Infraestructure.Entities.EFCore
{
    public partial class Usuario
    {
        public long Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Persona IdNavigation { get; set; } = null!;
    }
}
