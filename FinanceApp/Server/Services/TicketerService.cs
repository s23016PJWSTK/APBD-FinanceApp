using FinanceApp.Client.Models;
using FinanceApp.Server.Models;
using FinanceApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Server.Services
{
    public class TicketerService : ITicketerService
    {
        private readonly FinanceDbContext _context;

        public TicketerService(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task AddToWatchlist(string user, int TicketerId)
        {
            await _context.AddAsync(new WatchList_Ticketer
            {
                TicketerId = TicketerId,
                WatchListId = _context.WatchLists.FirstOrDefault(e => e.UserEmail == user).WatchListId
            });
        }

        public async Task CreateWatchList(string user)
        {
            await _context.AddAsync(new WatchList
            {
                UserEmail = user,
            });
        }

        public async Task RemoveFromWatchList(string user, int TicketerId)
        {
            _context.Remove(_context.WatchList_Ticketers.FirstOrDefault(e => e.TicketerId == TicketerId && e.WatchListId == _context.WatchLists.FirstOrDefault(e => e.UserEmail == user).WatchListId));
        }

        public async Task<TicketerToDb> GetTicketer(int id)
        {
            return await _context.Ticketers.FirstOrDefaultAsync();
        }

        public IQueryable<TicketerToDb> GetTicketers()
        {
            return _context.Ticketers;
        }

        public IQueryable<WatchList_Ticketer> GetWatchList_Ticketers(string user)
        {
            return _context.WatchList_Ticketers.Where(e => e.WatchListId == _context.WatchLists.FirstOrDefault(e => e.UserEmail == user).WatchListId);
        }

        public List<TicketerData> LoadTicketerDataFromDb(string code)
        {
            var TicketerId = _context.Ticketers.FirstOrDefault(e => e.Symbol == code).TicketerId;
            var tmp = _context.TicketerDatas
                .Where(e => e.TicketerId == TicketerId)
                .Where(e => e.Date >= DateTime.UtcNow.AddMonths(-3).AddDays(-2));
            if (tmp.FirstOrDefault() == null)
                return new List<TicketerData>();
            return tmp
                .Select(e => new TicketerData
                {
                    Close = e.Close,
                    High = e.Highest,
                    Low = e.Lowest,
                    Date = e.Date,
                    Open = e.Open,
                    Volume = e.Volume
                }).ToList();
        }

        public List<Article> LoadTicketerNewsFromDb(string code)
        {
            var TicketerId = _context.Ticketers.FirstOrDefault(e => e.Symbol == code).TicketerId;
            var tmp = _context.Articles
                .Where(e => e.TicketerId == TicketerId)
                .Where(e => e.published_utc >= DateTime.UtcNow.AddMonths(-3).AddDays(-2));
            if (tmp.FirstOrDefault() == null)
                return new List<Article>();
            return tmp
                .Select(e => new Article
                {
                    title = e.title,
                    article_url = e.article_url,
                    published_utc = e.published_utc,
                    publisher = new Publisher { name = e.name }
                }).ToList();
        }

        public async Task SaveTicketerDataToDb(string code, List<TicketerDataToDb> ticketerDatas)
        {
            await _context.AddRangeAsync(ticketerDatas);
            _context.SaveChanges();//dla async wyrzuca błąd kernel[13] i disposed of
        }

        public async Task SaveTicketerNewsToDb(string code, List<ArticleToDb> articles)
        {
            await _context.AddRangeAsync(articles);
            _context.SaveChanges();
        }
        public async Task SavaChangesToDb()
        {
            await _context.SaveChangesAsync();
        }
    }
}
