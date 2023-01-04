using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_CharacterCollection.Models
{
    public class CoinPouch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "CP")]
        public int Copper { get; set; }

        [Display(Name = "SP")]
        public int Silver { get; set; }

        [Display(Name = "GP")]
        public int Gold { get; set; }

        [Display(Name = "PP")]
        public int Platinum { get; set; }
    }
}
