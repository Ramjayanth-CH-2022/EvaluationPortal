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
    public class TestAttendeeHistoriesController : ControllerBase
    {
        private readonly evaluation_portalContext _context;

        public TestAttendeeHistoriesController(evaluation_portalContext context)
        {
            _context = context;
        }

        // GET: api/TestAttendeeHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestAttendeeHistory>>> GetTestAttendeeHistories()
        {
          if (_context.TestAttendeeHistories == null)
          {
              return NotFound();
          }
            return await _context.TestAttendeeHistories.ToListAsync();
        }

        // GET: api/TestAttendeeHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestAttendeeHistory>> GetTestAttendeeHistory(int id)
        {
          if (_context.TestAttendeeHistories == null)
          {
              return NotFound();
          }
            var testAttendeeHistory = await _context.TestAttendeeHistories.FindAsync(id);

            if (testAttendeeHistory == null)
            {
                return NotFound();
            }

            return testAttendeeHistory;
        }

        // PUT: api/TestAttendeeHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestAttendeeHistory(int id, TestAttendeeHistory testAttendeeHistory)
        {
            if (id != testAttendeeHistory.QuestionPaperCode)
            {
                return BadRequest();
            }

            _context.Entry(testAttendeeHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestAttendeeHistoryExists(id))
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

        // POST: api/TestAttendeeHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestAttendeeHistory>> PostTestAttendeeHistory(TestAttendeeHistory testAttendeeHistory)
        {
          if (_context.TestAttendeeHistories == null)
          {
              return Problem("Entity set 'evaluation_portalContext.TestAttendeeHistories'  is null.");
          }
            _context.TestAttendeeHistories.Add(testAttendeeHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestAttendeeHistory", new { id = testAttendeeHistory.QuestionPaperCode }, testAttendeeHistory);
        }

        // DELETE: api/TestAttendeeHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestAttendeeHistory(int id)
        {
            if (_context.TestAttendeeHistories == null)
            {
                return NotFound();
            }
            var testAttendeeHistory = await _context.TestAttendeeHistories.FindAsync(id);
            if (testAttendeeHistory == null)
            {
                return NotFound();
            }

            _context.TestAttendeeHistories.Remove(testAttendeeHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestAttendeeHistoryExists(int id)
        {
            return (_context.TestAttendeeHistories?.Any(e => e.QuestionPaperCode == id)).GetValueOrDefault();
        }
    }
}
