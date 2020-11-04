using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Timu_Vlad_Lab5.Models;

namespace Timu_Vlad_Lab5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ExpenseContext _context;

        public ExpensesController(ExpenseContext context)
        {
            _context = context;
        }

        // GET: api/Expenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expenses>>> GetExpense()
        {
            return await _context.Expense.ToListAsync();
        }

        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expenses>> GetExpenses(int id)
        {
            var expenses = await _context.Expense.FindAsync(id);

            if (expenses == null)
            {
                return NotFound();
            }

            return expenses;
        }

        // PUT: api/Expenses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpenses(int id, Expenses expenses)
        {
            if (id != expenses.Id)
            {
                return BadRequest();
            }

            _context.Entry(expenses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpensesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Expenses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Expenses>> PostExpenses(Expenses expenses)
        {
            _context.Expense.Add(expenses);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExpense), new { id = expenses.Id }, expenses);
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Expenses>> DeleteExpenses(int id)
        {
            var expenses = await _context.Expense.FindAsync(id);
            if (expenses == null)
            {
                return NotFound();
            }

            _context.Expense.Remove(expenses);
            await _context.SaveChangesAsync();

            return expenses;
        }

        private bool ExpensesExists(int id)
        {
            return _context.Expense.Any(e => e.Id == id);
        }
    }
}
