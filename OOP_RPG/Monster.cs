using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Monster
    {
        public Monster(string name, int strength, int defense, int hp)
        {
            this.Name = name;
            this.Strength = strength;
            this.Defense = defense;
            this.OriginalHP = hp;
            this.CurrentHP = hp;
        }

        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
    }
}