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


        //Modifiers, should be calculated depending on above scores
        [Required]
        public string StrModifier { get; set; }

        [Required]
        public string DexModifier { get; set; }

        [Required]
        public string ConModifier { get; set; }

        [Required]
        public string IntModifier { get; set; }

        [Required]
        public string WisModifier { get; set; }

        [Required]
        public string ChaModifier { get; set; }

        public string GetModifier(int score)
        {
            string modifier = "";

            if (score == 1)
            {
                modifier = "-5";
            }
            else if (score <= 3)
            {
                modifier = "-4";
            }
            else if (score <= 5)
            {
                modifier = "-3";
            }
            else if (score <= 7)
            {
                modifier = "-2";
            }
            else if (score <= 9)
            {
                modifier = "-1";
            }
            else if (score <= 11)
            {
                modifier = "+0";
            }
            else if (score <= 13)
            {
                modifier = "+1";
            }
            else if (score <= 15)
            {
                modifier = "+2";
            }
            else if (score <= 17)
            {
                modifier = "+3";
            }
            else if (score <= 19)
            {
                modifier = "+4";
            }
            else if (score == 20)
            {
                modifier = "+5";
            }

            return modifier;
        }
    }
}
