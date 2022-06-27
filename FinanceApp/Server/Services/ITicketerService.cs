using FinanceApp.Server.Models;

namespace FinanceApp.Server.Services
{
    public interface ITicketerService
    {
        public IQueryable<TicketerToDb> GetTicketers();
        public Task<TicketerToDb> GetTicketer(int id);
        public IQueryable<WatchList_Ticketer> GetWatchList_Ticketers(string user);
        public Task CreateWatchList(string user);
        public Task AddToWatchlist(string user, int TicketerId);
        public Task RemoveFromWatchList(string user, int TicketerId);
        public Task SavaChangesToDb();
    }
}
