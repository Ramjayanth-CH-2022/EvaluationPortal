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
    public class QuestionPatternsController : ControllerBase
    {
        private readonly evaluation_portalContext _context;

        public QuestionPatternsController(evaluation_portalContext context)
        {
            _context = context;
        }

        // GET: api/QuestionPatterns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionPattern>>> GetQuestionPatterns()
        {
          if (_context.QuestionPatterns == null)
          {
              return NotFound();
          }
            return await _context.QuestionPatterns.ToListAsync();
        }

        // GET: api/QuestionPatterns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionPattern>> GetQuestionPattern(int id)
        {
          if (_context.QuestionPatterns == null)
          {
              return NotFound();
          }
            var questionPattern = await _context.QuestionPatterns.FindAsync(id);

            if (questionPattern == null)
            {
                return NotFound();
            }

            return questionPattern;
        }

        // PUT: api/QuestionPatterns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionPattern(int id, QuestionPattern questionPattern)
        {
            if (id != questionPattern.Id)
            {
                return BadRequest();
            }

            _context.Entry(questionPattern).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionPatternExists(id))
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

        // POST: api/QuestionPatterns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionPattern>> PostQuestionPattern(QuestionPattern questionPattern)
        {
          if (_context.QuestionPatterns == null)
          {
              return Problem("Entity set 'evaluation_portalContext.QuestionPatterns'  is null.");
          }
            _context.QuestionPatterns.Add(questionPattern);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionPattern", new { id = questionPattern.Id }, questionPattern);
        }

        // DELETE: api/QuestionPatterns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionPattern(int id)
        {
            if (_context.QuestionPatterns == null)
            {
                return NotFound();
            }
            var questionPattern = await _context.QuestionPatterns.FindAsync(id);
            if (questionPattern == null)
            {
                return NotFound();
            }

            _context.QuestionPatterns.Remove(questionPattern);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionPatternExists(int id)
        {
            return (_context.QuestionPatterns?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
