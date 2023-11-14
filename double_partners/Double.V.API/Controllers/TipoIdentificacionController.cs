using Double.V.Domain.Database.Repositories;
using Double.V.Infraestructure.Database.Datasource;
using Double.V.Infraestructure.Database.DbContexts;
using Double.V.Infraestructure.Database.DbProvider;
using Double.V.Infraestructure.Database.Repositories.EFCore;
using Double.V.Presentation.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Double.V.API.Controllers
{
    [Authorize]
    [Route("api/tipo_identificacion")]
    [ApiController]
    public class TipoIdentificacionController : ControllerBase
    {

        private ITipoIdentificacionRepository tipoIdentificacionRepository;
        public TipoIdentificacionController(IDbProvider dbProvider, DoublePartnersContext context)
        {
            this.tipoIdentificacionRepository = dbProvider.InstanceRepository<ITipoIdentificacionRepository, EfCoreDataSource>(context);
        }


        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {


            List<TiposIdentificacionResponse> tipos = await tipoIdentificacionRepository.GetAll();
            var response = new
            {
                operation = true,                
                data = tipos,                
            };

            return Ok(response);
        }
    }


}
