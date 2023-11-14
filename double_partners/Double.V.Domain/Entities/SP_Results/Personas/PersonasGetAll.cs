using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.V.Domain.Entities.SP_Results.Personas
{

    [Keyless]
    public class PersonasGetAllResult
    {
        public long id { get; set; }
        public string identificacion { get; set; }
        public string nombres { get; set; }
        public string email { get; set; }
        public string login { get; set; }
    }
}
