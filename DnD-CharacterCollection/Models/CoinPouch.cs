using System.ComponentModel.DataAnnotations;

namespace DnD_CharacterCollection.Models
{
    public class CoinPouch
    {
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
