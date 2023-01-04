using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnD_CharacterCollection.Data;
using DnD_CharacterCollection.Models;
using Microsoft.AspNetCore.Authorization;

namespace DnD_CharacterCollection.Controllers
{
    [Authorize]
    public class CharactersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string _user;

        public CharactersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            _user = User.Identity.Name;
            var applicationDbContext = _context.Characters.Include(c => c.Attributes).Include(c => c.Wealth).Where(x => x.UserName == _user);
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
            ViewData["Alignments"] = new SelectList(_context.Set<Alignment>(), "Name", "Name");
            ViewData["Races"] = new SelectList(_context.Set<Race>(), "Name", "Name");
            ViewData["Classes"] = new SelectList(_context.Set<Class>(), "Name", "Name");

            return View();
        }

        // POST: Characters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name, string race, string characterClass, string alignment, int age, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int copper, int silver, int gold, int platinum, int level, int armorClass, int currentExp, int maxHitPoints)
        {
            Character character = Utilities.CreateCharacter(name, race, characterClass, alignment, age, strength, dexterity, constitution, intelligence, wisdom, charisma, copper, silver, gold, platinum, level, armorClass, currentExp, maxHitPoints, _user);


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
