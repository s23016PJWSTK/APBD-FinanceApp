using FinanceApp.Server.Models;
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

        public async Task SavaChangesToDb()
        {
            await _context.SaveChangesAsync();
        }
    }
}
