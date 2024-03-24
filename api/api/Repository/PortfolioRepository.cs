using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;

        public PortfolioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetUserPortfolioAsync(AppUser user)
        {
            return await _context.Portfolios
                .Where(u => u.AppUserId == user.Id)
                .Select(s => new Stock
                {
                    Id = s.StockId,
                    Symbol = s.Stock.Symbol,
                    CompanyName = s.Stock.CompanyName,
                    Purchase = s.Stock.Purchase,
                    LastDiv = s.Stock.LastDiv,
                    Industry = s.Stock.Industry,
                    MarketCap = s.Stock.MarketCap,
                }).ToListAsync();
        }

        public async Task<Portfolio> CreateAsync(Portfolio portfolio)
        {
            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<Portfolio> DeleteAsync(AppUser appUser, string symbol)
        {
            var portfolioModel = await _context.Portfolios
                .FirstOrDefaultAsync(p=>p.AppUserId == appUser.Id && p.Stock.Symbol.ToLower() == symbol.ToLower());

            if (portfolioModel == null)
            {
                return null;
            }

            _context.Portfolios.Remove(portfolioModel);
            await _context.SaveChangesAsync();
            return portfolioModel;
        }
    }
}
