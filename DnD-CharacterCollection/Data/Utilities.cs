using DnD_CharacterCollection.Models;

namespace DnD_CharacterCollection.Data
{
    public class Utilities
    {
        public static Character CreateCharacter(string name, int age, int height, int weight, string skin, string eyes, string hair, string race, string characterClass, string alignment, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int copper, int silver, int gold, int platinum, int armorClass, int maxHitPoints, string userName)
        {
            Character character = new Character();

            Attributes stats = new Attributes();
            stats.Strength = strength;
            stats.Dexterity = dexterity;
            stats.Constitution = constitution;
            stats.Intelligence = intelligence;
            stats.Wisdom = wisdom;
            stats.Charisma = charisma;
            stats.StrModifier = stats.GetModifier(strength);
            stats.DexModifier = stats.GetModifier(dexterity);
            stats.ConModifier = stats.GetModifier(constitution);
            stats.IntModifier = stats.GetModifier(intelligence);
            stats.WisModifier = stats.GetModifier(wisdom);
            stats.ChaModifier = stats.GetModifier(charisma);

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
            character.Height = height;
            character.Weight = weight;
            character.Eyes = eyes;
            character.Skin = skin;
            character.Hair = hair;
            character.ArmorClass = armorClass;
            character.MaxHitPoints = maxHitPoints;
            character.CurrentHitPoints = maxHitPoints;
            character.AttributesId = stats.Id;
            character.Attributes = stats;
            character.CoinPouchId = pouch.Id;
            character.Wealth = pouch;
            character.UserName = userName;

            return character;
        }

        public static Character AddExp(Character character, int addExp)
        {
            int current = character.CurrentExp;
            int newexp = current + addExp;

            character.CurrentExp = newexp;

            return character;
        }

        public static Character LevelUp(Character character, Attributes attributes, int newLevel, int armorClass, int maxHitPoints, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            character.Level = newLevel;
            character.ArmorClass = armorClass;

            if(character.CurrentHitPoints == character.MaxHitPoints)
            {
                character.CurrentHitPoints = maxHitPoints;
            }
            character.MaxHitPoints = maxHitPoints;


            character.UpdateLevelBoundary(character.Level);

            if(newLevel == 4 || newLevel == 8 || newLevel == 12 || newLevel == 16 || newLevel == 19)
            {
                attributes.Strength = strength;
                attributes.Dexterity = dexterity;
                attributes.Constitution = constitution;
                attributes.Intelligence = intelligence;
                attributes.Wisdom = wisdom;
                attributes.Charisma = charisma;
            }
            return character;
        }

        public static int UpdateHitPoints(Character character, int hitPoints)
        {
            int newHp = character.CurrentHitPoints + hitPoints;
            return newHp;
        }

        public static CoinPouch UpdateWealth(CoinPouch coinpouch, int copper, int silver, int gold, int platinum)
        {
            coinpouch.Copper += copper;
            coinpouch.Silver += silver;
            coinpouch.Gold += gold;
            coinpouch.Platinum += platinum;

            return coinpouch;
        }
    }
}