using api.Extensions;
using api.Interfaces;
using api.Models;
using api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepository;
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IFMPService _fmpService;

        public PortfolioController(UserManager<AppUser> userManager, IStockRepository stockRepository, IPortfolioRepository portfolioRepository, IFMPService fmpService)
        {
            _userManager = userManager;
            _stockRepository = stockRepository;
            _portfolioRepository = portfolioRepository;
            _fmpService= fmpService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            AppUser? appUser = await GetCurrentUserAsync();

            var userPortfolio = await _portfolioRepository.GetUserPortfolioAsync(appUser);
            return Ok(userPortfolio);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio(string symbol)
        {
            AppUser? appUser = await GetCurrentUserAsync();

            var stock = await _stockRepository.GetBySymbolAsync(symbol);
            if (stock == null)
            {
                stock = await _fmpService.FindStockBySymbolAsync(symbol);
                if (stock == null)
                {
                    return BadRequest("Stock doesnt exist");
                }
                await _stockRepository.CreateAsync(stock);
            }

            var userPortfolio = await _portfolioRepository.GetUserPortfolioAsync(appUser);
            if (userPortfolio.Any(p => p.Symbol.ToLower() == symbol.ToLower()))
            {
                return BadRequest("Stock already in portfolio");
            }

            var portfolioModel = new Portfolio
            {
                StockId = stock.Id,
                AppUserId = appUser.Id,
            };
            await _portfolioRepository.CreateAsync(portfolioModel);
            if (userPortfolio == null)
            {
                return StatusCode(500, "Portfolio not created");
            }

            return Created();
        }


        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePortfolio(string symbol)
        {
            AppUser? appUser = await GetCurrentUserAsync();

            var userPortfolio = await _portfolioRepository.GetUserPortfolioAsync(appUser);

            var filteredStock = userPortfolio.Where(s=>s.Symbol.ToLower() == symbol.ToLower()).ToList();
            if (filteredStock.Count() != 1)
            {
                return BadRequest("Stock not in portfolio");
            }

            await _portfolioRepository.DeleteAsync(appUser, symbol);
            return Ok();
        }

        private async Task<AppUser?> GetCurrentUserAsync()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            return appUser;
        }
    }
}
