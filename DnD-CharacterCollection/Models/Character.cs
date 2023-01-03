﻿using System.ComponentModel.DataAnnotations;

namespace DnD_CharacterCollection.Models
{
    public class Character
    {
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
        [Display(Name = "AC")]
        public int ArmorClass { get; set; }

        // Regularly changing data

        [Required]
        [Range(1,20, ErrorMessage = "Level has to between 1 and 20.")]
        public int Level {
            get { return Level; }
            set
            {
                goalExp = lvlBoundaries[Level];
                if(CurrentExp >= goalExp && Level != 20 )
                {
                    Level = Level + 1;
                }
            }
        }

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
        public string UserName { get; set; }


        private int goalExp; //changing depending on entered level
        private int[] lvlBoundaries = { 300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000, 100000, 120000, 140000, 165000, 195000, 225000, 265000, 305000, 355000, 0 };
    }
}
