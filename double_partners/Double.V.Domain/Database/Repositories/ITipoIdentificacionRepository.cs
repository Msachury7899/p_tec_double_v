using Double.V.Presentation.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.V.Domain.Database.Repositories
{
    public interface ITipoIdentificacionRepository: IRepository
    {
        public Task<List<TiposIdentificacionResponse>> GetAll();
    }
}
