using Double.V.API.Settings;
using Double.V.Domain.Database.Repositories;
using Double.V.Infraestructure.Database.Datasource;
using Double.V.Infraestructure.Database.DbContexts;
using Double.V.Infraestructure.Database.DbProvider;
using Double.V.Presentation.Request.Auth;
using Double.V.Presentation.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Double.V.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private IUserAuthRepository userAuthRepository;
        private JwtSettings jwtSettings;

        public AuthController(IDbProvider dbProvider, DoublePartnersContext context, IConfiguration configuration)
        {
            jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>()!;
            userAuthRepository = dbProvider.InstanceRepository<IUserAuthRepository, EfCoreDataSource>(context);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserAuthRequest userAuthRequest)
        {

            var existUser = await userAuthRepository.LoginUser(userAuthRequest);

            if (existUser == false)
            {
                return Unauthorized(new
                {
                    operation = false,
                                        
                });
            }

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("app", "backend_login"));
            claims.Add(new Claim("user_login", userAuthRequest.login));

            TimeSpan expire;
            if (!TimeSpan.TryParse("08:00", out expire))
                expire = TimeSpan.FromHours(2);

            var jwtToken = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.Add(expire),
                claims: claims,
                signingCredentials: signingCredentials
            );

            var response = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            var interactionResponse = new InteractionResponse<dynamic>
            {
                operation = true,
                response = new
                {
                    operation = true,
                    message = "Inicio Correcto",
                    token = response,
                },
            };

            return Ok(interactionResponse.response);
        }


        [Authorize]
        [HttpGet]
        [Route("checkSession")]
        public IActionResult CheckSession()
        {

            return NoContent();
        }


    }
}
