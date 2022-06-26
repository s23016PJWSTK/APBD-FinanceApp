using FinanceApp.Server.Models;

namespace FinanceApp.Server.Services
{
    public interface ITicketerService
    {
        public IQueryable<TicketerToDb> GetTicketers();
    }
}
