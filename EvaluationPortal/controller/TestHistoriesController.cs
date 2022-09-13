using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EvaluationPortal.Models;

namespace EvaluationPortal.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestHistoriesController : ControllerBase
    {
        private readonly evaluation_portalContext _context;

        public TestHistoriesController(evaluation_portalContext context)
        {
            _context = context;
        }

        // GET: api/TestHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestHistory>>> GetTestHistories()
        {
          if (_context.TestHistories == null)
          {
              return NotFound();
          }
            return await _context.TestHistories.ToListAsync();
        }

        // GET: api/TestHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestHistory>> GetTestHistory(int id)
        {
          if (_context.TestHistories == null)
          {
              return NotFound();
          }
            var testHistory = await _context.TestHistories.FindAsync(id);

            if (testHistory == null)
            {
                return NotFound();
            }

            return testHistory;
        }

        // PUT: api/TestHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestHistory(int id, TestHistory testHistory)
        {
            if (id != testHistory.SerialNumber)
            {
                return BadRequest();
            }

            _context.Entry(testHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestHistoryExists(id))
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

        // POST: api/TestHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestHistory>> PostTestHistory(TestHistory testHistory)
        {
          if (_context.TestHistories == null)
          {
              return Problem("Entity set 'evaluation_portalContext.TestHistories'  is null.");
          }
            _context.TestHistories.Add(testHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestHistory", new { id = testHistory.SerialNumber }, testHistory);
        }

        // DELETE: api/TestHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestHistory(int id)
        {
            if (_context.TestHistories == null)
            {
                return NotFound();
            }
            var testHistory = await _context.TestHistories.FindAsync(id);
            if (testHistory == null)
            {
                return NotFound();
            }

            _context.TestHistories.Remove(testHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestHistoryExists(int id)
        {
            return (_context.TestHistories?.Any(e => e.SerialNumber == id)).GetValueOrDefault();
        }
    }
}
