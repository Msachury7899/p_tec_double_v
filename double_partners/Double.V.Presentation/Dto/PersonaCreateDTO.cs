﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.V.Presentation.Dto
{
    public  class PersonaCreateDTO
    {
        public long id { get; set; }
        public string nombres { get; set; }
        public string email { get; set; }
        public string apellidos { get; set; }
        public string identificacion { get; set; }
        public short idTipoIdentificacion { get; set; }                        
    }
}
