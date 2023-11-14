using System;
using System.Collections.Generic;

namespace Double.V.Infraestructure.Entities.EFCore
{
    public partial class Persona
    {
        public long Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Email { get; set; }
        public string? Identificacion { get; set; }
        public short? IdTipoIdentificacion { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual TiposIdentificacion? IdTipoIdentificacionNavigation { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
