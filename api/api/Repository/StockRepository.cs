﻿using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetAllAsync(StockQueryObject query)
        {
            var stocks = _context.Stocks.Include(s => s.Comments).ThenInclude(c => c.AppUser).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            }
            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDescending ?
                        stocks.OrderByDescending(s => s.Symbol) :
                        stocks.OrderBy(s => s.Symbol);
                }
            }
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            stocks = stocks.Skip(skipNumber).Take(query.PageSize);
            return await stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Stock?> GetBySymbolAsync(string symbol)
        {
            return await _context.Stocks.FirstOrDefaultAsync(s => s.Symbol == symbol);
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateDto)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (existingStock == null)
            {
                return null;
            }

            existingStock.Symbol = updateDto.Symbol;
            existingStock.CompanyName = updateDto.CompanyName;
            existingStock.Purchase = updateDto.Purchase;
            existingStock.LastDiv = updateDto.LastDiv;
            existingStock.Industry = updateDto.Industry;
            existingStock.MarketCap = updateDto.MarketCap;

            await _context.SaveChangesAsync();
            return existingStock;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (stock == null)
            {
                return null;
            }
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return stock;
        }

        public async Task<bool> StockExistAsync(int id)
        {
            return await _context.Stocks.AnyAsync(s => s.Id == id);
        }
    }
}
