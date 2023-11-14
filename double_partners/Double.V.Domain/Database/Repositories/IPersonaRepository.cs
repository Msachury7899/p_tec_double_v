

using Double.V.Presentation.Dto;
using Double.V.Presentation.Response;

namespace Double.V.Domain.Database.Repositories
{
    public interface IPersonaRepository: IRepository
    {
        public Task<List<PersonasListResponse>> GetAllPersonas();

        public Task<bool> CreateAsync(PersonaCreateDTO personaCreateDTO);

    }
}
