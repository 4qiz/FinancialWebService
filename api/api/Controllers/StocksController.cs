﻿using api.Data;
using api.Dtos.Stock;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStockRepository _repository;

        public StocksController(ApplicationDbContext context, IStockRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: api/Stocks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _repository.GetAllAsync();
            return Ok(stocks.Select(s => s.ToStockDto()));
        }

        // GET: api/Stocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetById([FromRoute] int id)
        {
            var stock = await _repository.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        // PUT: api/Stocks/5
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateStockRequestDto updateDto)
        {
            try
            {
                var stockModel = await _repository.UpdateAsync(id, updateDto);

                if (stockModel == null)
                {
                    return NotFound();
                }
                return Ok(stockModel.ToStockDto());
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Stocks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDto();
            await _repository.CreateAsync(stockModel);
            return CreatedAtAction(
                nameof(GetById),
                new { id = stockModel.Id },
                stockModel.ToStockDto()
                );
        }

        // DELETE: api/Stocks/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _repository.DeleteAsync(id);
            if (stockModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        private bool StockExists(int id)
        {
            return _context.Stocks.Any(e => e.Id == id);
        }
    }
}
