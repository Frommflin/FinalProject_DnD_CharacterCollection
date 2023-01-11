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
        public static string user;

        public CharactersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            // Collecting username when user accesses the controller(Index-page) and saving in global variable
            user = User.Identity.Name;

            var characters = _context.Characters.Where(x => x.UserName == user);

            return View(await characters.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Characters == null)
            {
                return NotFound();
            }

            Character character = await _context.Characters
                .Include(c => c.Attributes)
                .Include(c => c.Wealth)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            var characters = _context.Characters.Where(x => x.UserName == user);
            ViewData["Characters"] = characters.ToList();

            return View(character);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditExp(int id, int addExp)
        {
            Character character = _context.Characters.Find(id);

            if (id != character.Id)
            {
                return NotFound();
            }

            character = Utilities.AddExp(character, addExp);

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
                if (character.CurrentExp >= character.goalExp)
                {
                    return RedirectToAction(nameof(Edit), new { id = id });
                }
            }
            return RedirectToAction(nameof(Details), new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RecoverHitPoints(int id, int hitPoints)
        {
            Character character = _context.Characters.Find(id);

            if (id != character.Id)
            {
                return NotFound();
            }

            character.CurrentHitPoints = Utilities.UpdateHitPoints(character, hitPoints);

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
            }
            return RedirectToAction(nameof(Details), new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoseHitPoints(int id, int hitPoints)
        {
            Character character = _context.Characters.Find(id);

            if (id != character.Id)
            {
                return NotFound();
            }

            character.CurrentHitPoints = Utilities.UpdateHitPoints(character, -hitPoints);

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
            }
            return RedirectToAction(nameof(Details), new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GainCoins(int id, int copper, int silver, int gold, int platinum)
        {
            Character character = _context.Characters.Find(id);

            if (id != character.Id)
            {
                return NotFound();
            }

            CoinPouch coinpouch = _context.CoinPouch.Find(character.Id);
            coinpouch = Utilities.UpdateWealth(coinpouch, copper, silver, gold, platinum);

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
            }
            return RedirectToAction(nameof(Details), new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoseCoins(int id, int copper, int silver, int gold, int platinum)
        {
            Character character = _context.Characters.Find(id);

            if (id != character.Id)
            {
                return NotFound();
            }

            CoinPouch coinpouch = _context.CoinPouch.Find(character.Id);
            coinpouch = Utilities.UpdateWealth(coinpouch, -copper, -silver, -gold, -platinum);

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
            }
            return RedirectToAction(nameof(Details), new { id = id });
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            user = User.Identity.Name;

            ViewData["Alignments"] = new SelectList(_context.Set<Alignment>(), "Name", "Name");
            ViewData["Races"] = new SelectList(_context.Set<Race>(), "Name", "Name");
            ViewData["Classes"] = new SelectList(_context.Set<Class>(), "Name", "Name");

            return View();
        }

        // POST: Characters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name, int age, int height, int weight, string skin, string eyes, string hair, string race, string characterClass, string alignment, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int copper, int silver, int gold, int platinum, int armorClass, int maxHitPoints)
        {
            Character character = Utilities.CreateCharacter(name, age, height, weight, skin, eyes, hair, race, characterClass, alignment, strength, dexterity, constitution, intelligence, wisdom, charisma, copper, silver, gold, platinum, armorClass, maxHitPoints, user);


            if (ModelState.IsValid)
            {
                _context.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Characters == null)
            {
                return NotFound();
            }

            Character character = await _context.Characters.Include(x => x.Attributes).FirstOrDefaultAsync(x => x.Id == id);
            if (character == null)
            {
                return NotFound();
            }
            ViewData["NewLevel"] = character.Level + 1;
            return View(character);
        }

        // POST: Characters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int newLevel, int armorClass, int maxHitPoints, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            Character character = _context.Characters.Find(id);
            

            if (id != character.Id)
            {
                return NotFound();
            }

            Attributes charAttributes = _context.Attributes.Find(character.AttributesId);
            character = Utilities.LevelUp(character, charAttributes, newLevel, armorClass, maxHitPoints, strength, dexterity, constitution, intelligence, wisdom, charisma);

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
                return RedirectToAction(nameof(Details), new { id = id });
            }
            ViewData["NewLevel"] = newLevel;
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Characters == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.FirstOrDefaultAsync(m => m.Id == id);
            
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

            Character character = await _context.Characters.FindAsync(id);
            Attributes attributes = await _context.Attributes.FindAsync(character.AttributesId);
            CoinPouch coinpouch = await _context.CoinPouch.FindAsync(character.CoinPouchId);

            if (character != null)
            {
                _context.Characters.Remove(character);
                _context.Attributes.Remove(attributes);
                _context.CoinPouch.Remove(coinpouch);
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
