using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.V.Presentation.Response
{
    public record TiposIdentificacionResponse(
        long id,
        string nombre_tipo  
    );    
}
