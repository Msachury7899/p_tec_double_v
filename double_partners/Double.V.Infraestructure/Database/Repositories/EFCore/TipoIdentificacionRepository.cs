using Double.v.Infraestructure.Database.Repositories.EFCore;
using Double.V.Domain.Database.Repositories;
using Double.V.Infraestructure.Database.DbContexts;
using Double.V.Presentation.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.V.Infraestructure.Database.Repositories.EFCore
{
    public class TipoIdentificacionRepository : InitRepository,ITipoIdentificacionRepository
    {
        public TipoIdentificacionRepository(DoublePartnersContext context) : base(context) {}

        public async Task<List<TiposIdentificacionResponse>> GetAll()
        {
            List<TiposIdentificacionResponse> tipos_identificacion = new List<TiposIdentificacionResponse>();

            try
            {
                tipos_identificacion = await _context.TiposIdentificacions.Select(e => new TiposIdentificacionResponse(
                    e.Id,
                    e.NombreTipo
                )).ToListAsync();

            }
            catch (Exception e)
            {

                throw e;
            }

            return tipos_identificacion;
        }
    }
}
