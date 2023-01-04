﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_CharacterCollection.Models
{
    public class Attributes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Strength { get; set; }

        [Required]
        public int Dexterity { get; set; }

        [Required]
        public int Constitution { get; set; }

        [Required]
        public int Intelligence { get; set; }

        [Required]
        public int Wisdom { get; set; }

        [Required]
        public int Charisma { get; set; }
    }
}
