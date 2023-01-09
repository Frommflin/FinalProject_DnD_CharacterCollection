using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_CharacterCollection.Models
{
    public class Attributes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Str")]
        public int Strength { get; set; }

        [Required]
        [Display(Name = "Dex")]
        public int Dexterity { get; set; }

        [Required]
        [Display(Name = "Con")]
        public int Constitution { get; set; }

        [Required]
        [Display(Name = "Int")]
        public int Intelligence { get; set; }

        [Required]
        [Display(Name = "Wis")]
        public int Wisdom { get; set; }

        [Required]
        [Display(Name = "Cha")]
        public int Charisma { get; set; }

    }
}
