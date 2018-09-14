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

        public Fight(Hero hero, Game game)
        {
            this.Monsters = new List<Monster>();
            this.hero = hero;
            this.game = game;

            this.AddMonster("Squid", 9, 8, 9, 20);
            this.AddMonster("Salmon", 10, 7, 8, 18);
            this.AddMonster("Octopus", 11, 12, 10, 21);
            this.AddMonster("Shark", 13, 15, 12, 24);

            Random rnd = new Random();
            int x = (int)rnd.Next(0, 4);
            this.enemy = this.Monsters[x];
        }

        public void AddMonster(string name, int strength, int defense, int speed, int hp)
        {
            var monster = new Monster(name, strength, defense, speed, hp);
            this.Monsters.Add(monster);
        }

        public void Start()
        {

            Console.WriteLine("You've encountered a " + enemy.Name + "! " + enemy.Strength + " Strength/" + enemy.Defense + " Defense/" +
            enemy.CurrentHP + " HP. What will you do?");
            Console.WriteLine("If you want to fight, enter 1.");
            Console.WriteLine("If you want to escape, enter any key.");
            var input = Console.ReadLine();
            if (input == "1")
            {
                this.HeroTurn();
            }
            else 
            {
                if (hero.Speed > enemy.Speed)
                {
                    this.game.Main();
                }
                else
                {
                    Console.WriteLine("Your speed is slower than the monster, so that you can't escape from the monster.");
                    this.HeroTurn();
                }
            }
        }

        public void HeroTurn()
        {
            var compare = hero.Strength - enemy.Defense;
            int damage;

            if (compare <= 0)
            {
                damage = 1;
                enemy.CurrentHP -= damage;
            }
            else
            {
                damage = compare;
                enemy.CurrentHP -= damage;
            }
            Console.WriteLine("You did " + damage + " damage!");

            if (enemy.CurrentHP <= 0)
            {
                this.Win();
            }
            else
            {
                this.MonsterTurn();
            }

        }

        public void MonsterTurn()
        {
            int damage;
            var compare = enemy.Strength - hero.Defense;
            if (compare <= 0)
            {
                damage = 1;
                hero.CurrentHP -= damage;
            }
            else
            {
                damage = compare;
                hero.CurrentHP -= damage;
            }
            Console.WriteLine(enemy.Name + " does " + damage + " damage!");
            if (hero.CurrentHP <= 0)
            {
                Console.WriteLine("You've been defeated! :( GAME OVER.)");
                Console.WriteLine("If you enter any key, you will escape out from this game. Bye");
                Console.ReadLine();
                return;
            }
            else
            {
                this.Start();
            }
        }

        public void Win()
        {

            Console.WriteLine(enemy.Name + " has been defeated! You win the battle!");
            Console.WriteLine(hero.Name + " gets " + enemy.Gold + " gold from " + enemy.Name + ".");
            hero.Gold = hero.Gold + enemy.Gold;
            Console.WriteLine("Now " + hero.Name + " has " + hero.Gold + " Gold.");
            game.Main();
        }
    }

}