using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnD_CharacterCollection.Data;
using DnD_CharacterCollection.Models;

namespace DnD_CharacterCollection.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharactersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Characters.Include(c => c.Attributes).Include(c => c.Wealth);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Characters == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .Include(c => c.Attributes)
                .Include(c => c.Wealth)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            ViewData["AttributesId"] = new SelectList(_context.Set<Attributes>(), "Id", "Id");
            ViewData["CoinPouchId"] = new SelectList(_context.Set<CoinPouch>(), "Id", "Id");
            return View();
        }

        // POST: Characters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Race,Class,Alignment,Age,ArmorClass,Level,CurrentExp,MaxHitPoints,CurrentHitPoints,AttributesId,CoinPouchId,UserName")] Character character)
        {
            if (ModelState.IsValid)
            {
                _context.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AttributesId"] = new SelectList(_context.Set<Attributes>(), "Id", "Id", character.AttributesId);
            ViewData["CoinPouchId"] = new SelectList(_context.Set<CoinPouch>(), "Id", "Id", character.CoinPouchId);
            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Characters == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            ViewData["AttributesId"] = new SelectList(_context.Set<Attributes>(), "Id", "Id", character.AttributesId);
            ViewData["CoinPouchId"] = new SelectList(_context.Set<CoinPouch>(), "Id", "Id", character.CoinPouchId);
            return View(character);
        }

        // POST: Characters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Race,Class,Alignment,Age,ArmorClass,Level,CurrentExp,MaxHitPoints,CurrentHitPoints,AttributesId,CoinPouchId,UserName")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AttributesId"] = new SelectList(_context.Set<Attributes>(), "Id", "Id", character.AttributesId);
            ViewData["CoinPouchId"] = new SelectList(_context.Set<CoinPouch>(), "Id", "Id", character.CoinPouchId);
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Characters == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .Include(c => c.Attributes)
                .Include(c => c.Wealth)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Characters == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Character'  is null.");
            }
            var character = await _context.Characters.FindAsync(id);
            if (character != null)
            {
                _context.Characters.Remove(character);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
          return _context.Characters.Any(e => e.Id == id);
        }
    }
}
