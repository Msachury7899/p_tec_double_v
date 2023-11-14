using Double.V.Domain.Database.Repositories;
using Double.V.Infraestructure.Database.Datasource;
using Double.V.Infraestructure.Database.DbContexts;
using Double.V.Infraestructure.Database.DbProvider;
using Double.V.Presentation.Dto;
using Double.V.Presentation.Request;
using Double.V.Presentation.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Double.V.API.Controllers
{
    [Authorize]
    [Route("api/personas")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private IPersonaRepository personaRepository;
        private IUserAuthRepository userAuthRepository;
        public PersonasController(IDbProvider dbProvider, DoublePartnersContext context )
        {
            this.personaRepository  = dbProvider.InstanceRepository<IPersonaRepository, EfCoreDataSource>(context);
            this.userAuthRepository = dbProvider.InstanceRepository<IUserAuthRepository, EfCoreDataSource>(context);
        }


        [HttpGet]
        public async Task<ActionResult> GetAllAsync() {                        

            var personas = await personaRepository.GetAllPersonas();
            var response = new
            {
                operation = true,
                data = personas,
            };

            return Ok(response);
        }


        [HttpPost("createPersona")]
        public async Task<ActionResult> CreatePersonaAsync([FromBody] CreatePersonaUsuarioRequest createPersonaUsuarioRequest)
        {
            var interactionResponse = new InteractionResponse<string>();

            var userCreateDto = new UsuarioCreateDTO
            {
                login = createPersonaUsuarioRequest.login,
                password = createPersonaUsuarioRequest.password
            };

            var idNewUsuario = await  this.userAuthRepository.CreateAsync(userCreateDto);
            if (idNewUsuario == -1)
            {
                interactionResponse.operation = false;
                interactionResponse.response = "Hubo un error revisa tus datos de entrada";
                return Ok(interactionResponse);
            }

            var personaCreateDto = new PersonaCreateDTO
            {
                id = idNewUsuario,
                nombres = createPersonaUsuarioRequest.nombres,
                apellidos = createPersonaUsuarioRequest.apellidos,
                identificacion = createPersonaUsuarioRequest.identificacion,
                idTipoIdentificacion = createPersonaUsuarioRequest.idTipoIdentificacion,
                email = createPersonaUsuarioRequest.email
            };

            bool newPersona = await this.personaRepository.CreateAsync(personaCreateDto);

            interactionResponse.operation = true;
            interactionResponse.response = "Persona Creada Existosamente";

            return Ok(interactionResponse);


        }
    }
}
