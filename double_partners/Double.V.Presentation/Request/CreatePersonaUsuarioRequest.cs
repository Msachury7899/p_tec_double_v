using Double.V.Presentation.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.V.Presentation.Request
{
    public class CreatePersonaUsuarioRequest
    {
        [Required]
        public string nombres { get; set; }
        [Required]
        public string apellidos { get; set; }
        [Required]
        public string identificacion { get; set; }
        [Required]
        public short idTipoIdentificacion { get; set; }
        [Required]
        public string login { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string email { get; set; }
    }
}
