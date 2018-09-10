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
        public Monster enemy { get; set; }
        
        public Fight(Hero hero, Game game) {
            this.Monsters = new List<Monster>();
            this.hero = hero;
            this.game = game;

            this.AddMonster("Squid", 9, 8, 20);
            // added new monsters
            this.AddMonster("Salmon", 10, 7, 18);
            this.AddMonster("Octopus", 17, 12, 21);
            this.AddMonster("Shark", 28, 28, 32);

            //Call 1st monster 
            //this.enemy = this.Monsters[0];

            //Call Last Monster
            //this.enemy = this.Monsters.Last();


            //Call Second Monster
            //this.enemy = monsters.ElementAt(1);


            //Call Less 20 heat point monster 
            //this.enemy = this.Monsters.Where(p => p.OriginalHP < 20).First();


            //Call at leat 11 strength monster
            //this.enemy = this.Monsters.Where(p => p.Strength >= 11).First();


            //Call random monster
            Random rnd = new Random();
            int x = (int)rnd.Next(0, 4);
            this.enemy = this.Monsters[x]; 
        }
        
        public void AddMonster(string name, int strength, int defense, int hp) {
            var monster = new Monster(name, strength, defense, hp);
            
            /*monster.Name = name;
            monster.Strength = strength;
            monster.Defense = defense;
            monster.OriginalHP = hp;
            monster.CurrentHP = hp;*/
            
            this.Monsters.Add(monster);
        }
        
        public void Start() {

            Console.WriteLine("You've encountered a " + enemy.Name + "! " + enemy.Strength + " Strength/" + enemy.Defense + " Defense/" + 
            enemy.CurrentHP + " HP. What will you do?");
            Console.WriteLine("1. Fight");
            var input = Console.ReadLine();
            if (input == "1") {
                this.HeroTurn();
            }
            else { 
                this.game.Main();
            }
        }
        
        public void HeroTurn(){
           //var enemy = Monster;
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
               this.Win();
           }
           else
           {
               this.MonsterTurn();
           }
           
        }
        
        public void MonsterTurn(){
           //var enemy = monster;
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
        
        public void Win() {
            //var enemy = monster;
            Console.WriteLine(enemy.Name + " has been defeated! You win the battle!");
            game.Main();
        }
        
        public void Lose() {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            return;
        }
        
    }
    
}