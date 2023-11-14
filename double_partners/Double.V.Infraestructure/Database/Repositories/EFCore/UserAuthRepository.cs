using Double.V.Domain.Database.Repositories;
using Double.V.Presentation.Request.Auth;
using Double.v.Infraestructure.Database.Repositories.EFCore;
using Double.V.Infraestructure.Database.DbContexts;
using Microsoft.EntityFrameworkCore;
using Double.V.Infraestructure.Entities.EFCore;
using Double.V.Presentation.Dto;

namespace Double.V.Infraestructure.Database.Repositories.EFCore
{
    public class UserAuthRepository : InitRepository, IUserAuthRepository
    {
        public UserAuthRepository(DoublePartnersContext context) : base(context) { }

        public Task<bool> ExistUser(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LoginUser(UserAuthRequest userAuthRequest)
        {
            var execution = false;
            try
            {
                execution = await _context.Usuarios.Where(e => e.Login == userAuthRequest.login && e.Password == userAuthRequest.password).AnyAsync();
            }
            catch (Exception)
            {
                //throw;
                
            }
            return execution;
        }


        public async Task<long> CreateAsync(UsuarioCreateDTO dto)
        {
            long newId = -1;
            try
            {
                var newRegister = new Usuario
                {                    
                    Login = dto.login,
                    Password = dto.password,
                    FechaCreacion = DateTime.UtcNow,
                };

                var executionEntity = await _context.Usuarios.AddAsync(newRegister);
                if (_context.SaveChanges() == 1)
                {
                    newId = executionEntity.Entity.Id;
                }

            }
            catch (Exception)
            {
                throw;
            }
            return newId;
        }


    }
}
