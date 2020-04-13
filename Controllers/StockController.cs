using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dockertraining_compose_anthony_yildirim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dockertraining_compose_anthony_yildirim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockContext db;

        public StockController(StockContext context)
        {
            db = context;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            var stocks = db.Stocks.Select(s => $"{s.Id} - {s.Symbol} - {s.Description}");
            if (stocks == null || stocks.Count() < 1)
            {
                return NotFound();
            }
            return Ok(stocks);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStock(int id)
        {
            var stock = await db.Stocks.FindAsync(id);
            if (stock == default(Stock))
            {
                return NotFound();
            }
            return Ok(stock);
        }

        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] Stock stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await db.AddAsync(stock);
            await db.SaveChangesAsync();
            return Ok(stock.Id);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStock([FromBody] Stock stock)
        {
            var dbStock = await db.Stocks.FindAsync(stock?.Id);
            if (stock == default(Stock))
            {
                return NotFound();
            }
            db.Stocks.Remove(dbStock);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}