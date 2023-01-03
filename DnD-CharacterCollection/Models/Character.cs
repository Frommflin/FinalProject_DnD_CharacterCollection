using System.ComponentModel.DataAnnotations;

namespace DnD_CharacterCollection.Models
{
    public class Character
    {
        public int Id { get; set; }

        // Character's personal info
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string Alignment { get; set; }
        public int Age { get; set; }

        public int ArmorClass { get; set; }

        // Regularly changing data
        public int Level
        {
            get { return Level; }
            set
            {
                goalExp = lvlBoundaries[Level];
                if (CurrentExp >= goalExp && Level != 20)
                {
                    Level = Level + 1;
                }
            }
        }

        public int CurrentExp { get; set; }

        public int MaxHitPoints { get; set; }

        public int CurrentHitPoints { get; set; }

        //Character's attributes
        public int AttributesId { get; set; }
        public Attributes Attributes { get; set; }

        // Character's wealth
        public int CoinPouchId { get; set; }
        public CoinPouch Wealth { get; set; }


        private int goalExp; //changing depending on entered level
        private int[] lvlBoundaries = { 300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000, 100000, 120000, 140000, 165000, 195000, 225000, 265000, 305000, 355000, 0 };
    }
}
