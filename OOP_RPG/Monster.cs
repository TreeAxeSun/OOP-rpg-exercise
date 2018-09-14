using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Monster
    {

        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public int Gold { get; set; }

        public Monster(string name, int strength, int defense, int speed, int hp)
        {
            this.Name = name;
            this.Strength = strength;
            this.Defense = defense;
            this.Speed = speed;
            this.OriginalHP = hp;
            this.CurrentHP = hp;
            this.Gold = 5;
        }
    }
}