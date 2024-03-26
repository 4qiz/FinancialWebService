using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel) 
            => new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Dividend = stockModel.Dividend,
                Comments = stockModel.Comments.Select(c=>c.ToDtoFromComment()).ToList(),
            };

        public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto)
            => new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap,
                Dividend= stockDto.Dividend,
                
            };

        public static Stock ToStockFromFMP(this FMPStock stockDto)
            => new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = (decimal) stockDto.Price,
                LastDiv = (decimal)stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MktCap,
                Dividend = 99,

            };
    }
}
