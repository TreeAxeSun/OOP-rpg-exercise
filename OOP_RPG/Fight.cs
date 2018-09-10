using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Fight
    {
        List<Monster> Monsters { get; set; }
        public Game game { get; set; }
        public Hero hero { get; set; }

        
        public Fight(Hero hero, Game game) {
            this.Monsters = new List<Monster>();
            this.hero = hero;
            this.game = game;
            this.AddMonster("Squid", 9, 8, 20);
            this.AddMonster("Salmon", 10, 7, 18);
            this.AddMonster("Octopus", 17, 12, 21);
            this.AddMonster("Shark", 28, 28, 32);
        }
        
        public void AddMonster(string name, int strength, int defense, int hp) {
            var monster = new Monster();
            monster.Name = name;
            monster.Strength = strength;
            monster.Defense = defense;
            monster.OriginalHP = hp;
            monster.CurrentHP = hp;
            this.Monsters.Add(monster);
        }
        
        public void Start() {
            //Call 1st monster 
            //var enemy = this.Monsters[0];

            var enemies = this.Monsters;

            //Call Last Monster
            //var LastMonster = enemies.Last();
            //var enemy = LastMonster;

            //Call Second Monster
            //var SecondMonster = enemies.ElementAt(1);
            //var enemy = LastMonster;

            //Call Less 20 heat point monster 
            //var Less20HPMonsters = enemies.Where(p => p.OriginalHP < 20).First();
            //var enemy = Less20HPMonsters

            //Call at leat 11 strength monster
            //var Over11StrMonster = enemies.Where(p => p.Strength >= 11).First();
            //var enemy = Over11StrMonster;

            //Call random monster
            Random rnd = new Random();
            int x = (int)rnd.Next(0, 4);
            var enemy = enemies[x];

            Console.WriteLine("You've encountered a " + enemy.Name + "! " + enemy.Strength + " Strength/" + enemy.Defense + " Defense/" + 
            enemy.CurrentHP + " HP. What will you do?");
            Console.WriteLine("1. Fight");
            var input = Console.ReadLine();
            if (input == "1") {
                this.HeroTurn(enemy);
            }
            else { 
                this.game.Main();
            }
        }
        
        public void HeroTurn(Monster monster){
           var enemy = monster;
           var compare = hero.Strength - enemy.Defense;
           int damage;
           
           if(compare <= 0) {
               damage = 1;
               enemy.CurrentHP -= damage;
           }
           else{
               damage = compare;
               enemy.CurrentHP -= damage;
           }
           Console.WriteLine("You did " + damage + " damage!");
           
           if(enemy.CurrentHP <= 0){
               this.Win(enemy);
           }
           else
           {
               this.MonsterTurn(enemy);
           }
           
        }
        
        public void MonsterTurn(Monster monster){
           var enemy = monster;
           int damage;
           var compare = enemy.Strength - hero.Defense;
           if(compare <= 0) {
               damage = 1;
               hero.CurrentHP -= damage;
           }
           else{
               damage = compare;
               hero.CurrentHP -= damage;
           }
           Console.WriteLine(enemy.Name + " does " + damage + " damage!");
           if(hero.CurrentHP <= 0){
               this.Lose();
           }
           else
           {
               this.Start();
           }
        }
        
        public void Win(Monster monster) {
            var enemy = monster;
            Console.WriteLine(enemy.Name + " has been defeated! You win the battle!");
            game.Main();
        }
        
        public void Lose() {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            return;
        }
        
    }
    
}