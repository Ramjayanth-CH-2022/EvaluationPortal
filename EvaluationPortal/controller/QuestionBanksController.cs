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
    public class QuestionBanksController : ControllerBase
    {
        private readonly evaluation_portalContext _context;

        public QuestionBanksController(evaluation_portalContext context)
        {
            _context = context;
        }

        // GET: api/QuestionBanks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionBank>>> GetQuestionBanks()
        {
          if (_context.QuestionBanks == null)
          {
              return NotFound();
          }
            return await _context.QuestionBanks.ToListAsync();
        }

        // GET: api/QuestionBanks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionBank>> GetQuestionBank(int id)
        {
          if (_context.QuestionBanks == null)
          {
              return NotFound();
          }
            var questionBank = await _context.QuestionBanks.FindAsync(id);

            if (questionBank == null)
            {
                return NotFound();
            }

            return questionBank;
        }

        // PUT: api/QuestionBanks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionBank(int id, QuestionBank questionBank)
        {
            if (id != questionBank.QuestionId)
            {
                return BadRequest();
            }

            _context.Entry(questionBank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionBankExists(id))
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

        // POST: api/QuestionBanks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionBank>> PostQuestionBank(QuestionBank questionBank)
        {
          if (_context.QuestionBanks == null)
          {
              return Problem("Entity set 'evaluation_portalContext.QuestionBanks'  is null.");
          }
            _context.QuestionBanks.Add(questionBank);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionBank", new { id = questionBank.QuestionId }, questionBank);
        }

        // DELETE: api/QuestionBanks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionBank(int id)
        {
            if (_context.QuestionBanks == null)
            {
                return NotFound();
            }
            var questionBank = await _context.QuestionBanks.FindAsync(id);
            if (questionBank == null)
            {
                return NotFound();
            }

            _context.QuestionBanks.Remove(questionBank);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionBankExists(int id)
        {
            return (_context.QuestionBanks?.Any(e => e.QuestionId == id)).GetValueOrDefault();
        }
    }
}
