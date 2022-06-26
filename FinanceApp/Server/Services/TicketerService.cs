using FinanceApp.Server.Models;

namespace FinanceApp.Server.Services
{
    public class TicketerService : ITicketerService
    {
        private readonly FinanceDbContext _context;

        public TicketerService(FinanceDbContext context)
        {
            _context = context;
        }

        public IQueryable<TicketerToDb> GetTicketers()
        {
            return _context.Ticketers;
        }
    }
}
