using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DnD_CharacterCollection.Models;

namespace DnD_CharacterCollection.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Attributes> Attributes { get; set; }
        public DbSet<CoinPouch> CoinPouch { get; set; }
        public DbSet<Alignment> Alignments { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Class> Classes { get; set; }

    }
}