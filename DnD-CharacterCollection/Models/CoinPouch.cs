﻿using System.ComponentModel.DataAnnotations;

namespace DnD_CharacterCollection.Models
{
    public class CoinPouch
    {
        public int Id { get; set; }
        public int Copper { get; set; }
        public int Silver { get; set; }
        public int Gold { get; set; }
        public int Platinum { get; set; }
    }
}
