
using Double.V.Presentation.Dto;
using Double.V.Presentation.Request.Auth;


namespace Double.V.Domain.Database.Repositories
{
    public interface IUserAuthRepository: IRepository
    {                
        Task<bool> LoginUser(UserAuthRequest userAuthRequest);

        Task<long> CreateAsync(UsuarioCreateDTO usuarioCreateDTO);
    }
}
