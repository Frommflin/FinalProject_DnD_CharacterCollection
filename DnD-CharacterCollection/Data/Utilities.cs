using DnD_CharacterCollection.Models;

namespace DnD_CharacterCollection.Data
{
    public class Utilities
    {
        public static Character CreateCharacter(string name, string race, string characterClass, string alignment, int age, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int copper, int silver, int gold, int platinum, int level, int armorClass, int currentExp, int maxHitPoints, string userName)
        {
            Character character = new Character();

            Attributes stats = new Attributes();
            stats.Strength = strength;
            stats.Dexterity = dexterity;
            stats.Constitution = constitution;
            stats.Intelligence = intelligence;
            stats.Wisdom = wisdom;
            stats.Charisma = charisma;

            CoinPouch pouch = new CoinPouch();
            pouch.Copper = copper;
            pouch.Silver = silver;
            pouch.Gold = gold;
            pouch.Platinum = platinum;


            character.Name = name;
            character.Race = race;
            character.Class = characterClass;
            character.Alignment = alignment;
            character.Age = age;
            character.Level = level;
            character.ArmorClass = armorClass;
            character.CurrentExp = currentExp;
            character.MaxHitPoints = maxHitPoints;
            character.CurrentHitPoints = maxHitPoints;
            character.AttributesId = stats.Id;
            character.CoinPouchId = pouch.Id;
            character.UserName = userName;

            return character;
        }
    }
}
