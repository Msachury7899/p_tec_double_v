using Double.V.Domain.Database.Repositories;
using Double.v.Infraestructure.Database.Repositories.EFCore;
using Double.V.Infraestructure.Database.DbContexts;
using Double.V.Presentation.Response;
using Microsoft.EntityFrameworkCore;
using Double.V.Presentation.Dto;
using Double.V.Infraestructure.Entities.EFCore;

namespace Double.V.Infraestructure.Database.Repositories.EFCore
{
    public class PersonaRepository : InitRepository, IPersonaRepository
    {
        public PersonaRepository(DoublePartnersContext context) : base(context) { }

        public async Task<List<PersonasListResponse>> GetAllPersonas()
        {
            List<PersonasListResponse> personas = new List<PersonasListResponse>();

            try
            {
              personas = _context.SP_PERSONAS_GET_ALL.FromSqlRaw($"EXEC dbo.SP_PERSONAS_GET_ALL")                    
                    .AsEnumerable()
                    .Select(e => 
                    new PersonasListResponse(
                        e.id,
                        e.identificacion,
                        e.nombres,
                        e.email,
                        e.login
                    )    
                ).ToList();

            }
            catch (Exception e)
            {

                throw e;
            }
            
            return personas;
        }


        public async Task<bool> CreateAsync(PersonaCreateDTO dto)
        {
            var status = false;
            try
            {
                var newRegister = new Persona
                {
                    Id = dto.id,
                    Nombres = dto.nombres,
                    Apellidos = dto.apellidos,
                    FechaCreacion = DateTime.UtcNow,
                    Email = dto.email,
                    Identificacion = dto.identificacion,
                    IdTipoIdentificacion = dto.idTipoIdentificacion,
                    
                };

                await _context.Personas.AddAsync(newRegister);
                if (_context.SaveChanges() == 1)
                {
                    status = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }
    }
}
