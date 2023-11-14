
using Double.V.API.Settings;
using Double.V.Infraestructure.Database.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Double.V.API.Extensions
{
      public static partial class Extensions
        {
            public static IServiceCollection AddDB(this IServiceCollection services)
            {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>()!;
            DBSettings dbSettings = configuration.GetSection(nameof(DBSettings)).Get<DBSettings>()!;

            services.AddDbContext<DoublePartnersContext>(opt =>
            {
                opt.UseSqlServer(dbSettings.ConnectionChain);
            });

            return services;
            }

        }

}
