using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionWarriors.Engine.Entitys
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string CharacterTitle { get; set; }
        public CharacterClass CharacterCategory { get; set; }
        public int CharacterLife { get; set; }
        public int CharacterAmor { get; set; }
        public int CharacterAttackPower { get; set; }
        public string CharacterSpecialPower { get; set; }

    }

    public enum CharacterClass
    {
        Barbarian = 0,
        Bard = 1,
        Wizard = 2,
        Cleric = 3,
        Druid = 4,
        Sorcerer = 5,
        Warrior = 6,
        Rouge = 7,
        Mage = 8,
        Monk = 9,
        Paladin = 10
    }
}
