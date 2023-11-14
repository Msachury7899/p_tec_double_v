using System;
using System.Collections.Generic;

namespace Double.V.Infraestructure.Entities.EFCore
{
    public partial class TiposIdentificacion
    {
        public TiposIdentificacion()
        {
            Personas = new HashSet<Persona>();
        }

        public short Id { get; set; }
        public string? NombreTipo { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
