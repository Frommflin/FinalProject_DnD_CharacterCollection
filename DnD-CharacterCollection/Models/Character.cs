using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_CharacterCollection.Models
{
    public class Character
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Character's personal info
        [Required(ErrorMessage = "Character has to have a name")]
        public string Name { get; set; }
        
        [Required]
        public string Race { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        public string Alignment { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Height (cm)")]
        public int Height { get; set; }

        [Required]
        [Display(Name = "Weight (kg)")]
        public int Weight { get; set; }

        [Required]
        [Display(Name = "Eye color")]
        public string Eyes { get; set; }

        [Required]
        [Display(Name = "Complexion")]
        public string Skin { get; set; }

        [Required]
        [Display(Name = "Hair color")]
        public string Hair { get; set; }


        // Changing data

        [Required]
        [Display(Name = "AC")]
        public int ArmorClass { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Level has to between 1 and 20.")]
        public int Level { get; set; }

        [Required]
        [Range(0, 355000, ErrorMessage = "EXP cannot be negative or exceed max level (355000 exp)")]
        [Display(Name = "Experience points")]
        public int CurrentExp { get; set; }

        [Required]
        [Display(Name = "Max HP")]
        public int MaxHitPoints { get; set; }

        [Display(Name = "Current HP")]
        public int CurrentHitPoints { get; set; }

        //Character's attributes
        [Required]
        public int AttributesId { get; set; }
        public Attributes Attributes { get; set; }

        // Character's wealth
        [Required]
        public int CoinPouchId { get; set; }
        public CoinPouch Wealth { get; set; }

        // User information to limit who can see character
        [Required]
        public string UserName { get; set; }

        [Required]
        public int goalExp { get; set; } //changing depending on entered level


        private int[] lvlBoundaries = { 300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000, 100000, 120000, 140000, 165000, 195000, 225000, 265000, 305000, 355000, 0 };

        public Character()
        {
            Level = 1;
            CurrentExp = 0;
            UpdateLevelBoundary(Level);
        }

        public void UpdateLevelBoundary(int level)
        {
            goalExp = lvlBoundaries[level - 1];
        }

    }
}
