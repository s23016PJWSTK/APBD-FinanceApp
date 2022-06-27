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
        public List<Client.Models.TicketerData> LoadTicketerDataFromDb(string code);
        public List<Shared.Article> LoadTicketerNewsFromDb(string code);
        public Task SaveTicketerDataToDb(string code, List<TicketerDataToDb> ticketerDatas);
        public Task SaveTicketerNewsToDb(string code, List<ArticleToDb> articles);
        public Task SavaChangesToDb();
    }
}
