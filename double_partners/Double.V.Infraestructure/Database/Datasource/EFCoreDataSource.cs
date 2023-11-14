using Double.V.Domain.Database;
using Double.V.Domain.Database.Repositories;
using Double.V.Infraestructure.Database.DbContexts;
using Double.V.Infraestructure.Database.Repositories.EFCore;


namespace Double.V.Infraestructure.Database.Datasource
{
    public class EfCoreDataSource: DataSourceCustom
    {
        private DoublePartnersContext context;
        public EfCoreDataSource(DoublePartnersContext context) :base() {
            this.context = context;
            this.InitFactory();
        }

        override
        protected void InitFactory()
        {
            
            RegisterRepository<IUserAuthRepository, UserAuthRepository>(context);
            RegisterRepository<IPersonaRepository, PersonaRepository>(context);
            RegisterRepository<ITipoIdentificacionRepository, TipoIdentificacionRepository>(context);
        }
    }
    
}
