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
        [Range(0, int.MaxValue)]
        public int Copper { get; set; }

        [Display(Name = "SP")]
        [Range(0, int.MaxValue)]
        public int Silver { get; set; }

        [Display(Name = "GP")]
        [Range(0, int.MaxValue)]
        public int Gold { get; set; }

        [Display(Name = "PP")]
        [Range(0, int.MaxValue)]
        public int Platinum { get; set; }

    }
}
