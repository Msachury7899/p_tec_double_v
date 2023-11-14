using Double.V.Infraestructure.Database.DbContexts;

namespace Double.v.Infraestructure.Database.Repositories.EFCore
{
    public class InitRepository
    {
        protected DoublePartnersContext _context;
        
        public InitRepository(DoublePartnersContext context)
        {
            this._context = context;
        }
    }
}
