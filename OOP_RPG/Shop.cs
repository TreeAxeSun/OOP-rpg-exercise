using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Shop
    {
        public List<Weapon> Weapons { get; set; }
        public List<Armor> Armors { get; set; }
        public List<Potion> Potions { get; set; }
        public Game game { get; set; }
        public Hero hero { get; set; }
        public Dictionary<string, object> buyProducts { get; set; }
        public Dictionary<string, object> sellProducts { get; set; }

        public Shop(Hero hero, Game game)
        {
            this.hero = hero;
            this.game = game;
            this.Weapons = new List<Weapon>();
            this.Armors = new List<Armor>();
            this.Potions = new List<Potion>();
            this.buyProducts = new Dictionary<string, object>();
            this.sellProducts = new Dictionary<string, object>();

            this.AddWeapon("Sword", 10, 2, 3);
            this.AddWeapon("Axe", 12, 3, 4);
            this.AddWeapon("LongSword", 20, 5, 7);

            this.AddArmor("Wooden Armor", 10, 2, 3);
            this.AddArmor("Metal Armor", 20, 5, 7);

            this.AddPotion("Healing Potion", 5, 5, 2);
        }

        public void AddWeapon(string name, int originalvalue, int resellvalue, int strength)
        {
            var weapon = new Weapon(name, originalvalue, resellvalue, strength);
            this.Weapons.Add(weapon);
        }

        public void AddArmor(string name, int originalvalue, int resellvalue, int defense)
        {
            var armor = new Armor(name, defense, originalvalue, resellvalue);
            this.Armors.Add(armor);
        }

        public void AddPotion(string name, int hp, int originalvalue, int resellvalue)
        {
            var potion = new Potion(name, hp, originalvalue, resellvalue);
            this.Potions.Add(potion);
        }

        public void Menu()
        {
            buyProducts.Clear();
            Console.WriteLine($"Welcome to my shop! What woudld you like to do?");
            Console.WriteLine($"1) Buy Item");
            Console.WriteLine($"2) Sell Item");
            Console.WriteLine($"3) Return to Game Menu");
            var input = Console.ReadLine();
            if (input == "1")
            {
                ShowInventory();
            }
            else if (input == "2")
            {
                BuyfromUser();
            }
            else
            {
                game.Main();
            }
        }


        public void ShowInventory()
        {
            for (var i = 0; i < Weapons.Count(); i++)
            {
                Console.WriteLine($"W{i} - Name: {Weapons[i].Name} / Original Value: {Weapons[i].OriginalValue}");
                buyProducts.Add($"W{i}", Weapons[i]);
            }
            for (var i = 0; i < Armors.Count(); i++)
            {
                Console.WriteLine($"A{i} - Name: {Armors[i].Name} / Original Value: {Armors[i].OriginalValue}");
                buyProducts.Add($"A{i}", Armors[i]);
            }
            for (var i = 0; i < Potions.Count(); i++)
            {
                Console.WriteLine($"P{i} - Name: {Potions[i].Name} / Original Value: {Potions[i].OriginalValue}");
                buyProducts.Add($"P{i}", Potions[i]);
            }
            Console.WriteLine("Buy item or return to menu");
            Console.WriteLine("If you want to buy item, type the b");
            Console.WriteLine("If you want to return to menu, type the r");

            var choose = Console.ReadLine();
            if (choose == "b")
            {
                Sell();
            }
            else if (choose == "r")
            {
                Menu();
            }
            else
            {
                Console.WriteLine("You type wrong letter. Please enter correct letter.");
                Console.WriteLine("");
                Menu();
            }
        }

        public void BuyfromUser()
        {
            for (var i = 0; i < hero.WeaponsBag.Count(); i++)
            {
                Console.WriteLine($"W{i} - Name: {hero.WeaponsBag[i].Name} / Resell Value: {hero.WeaponsBag[i].ResellValue}");
                sellProducts.Add($"W{i}", hero.WeaponsBag[i]);
            }
            for (var i = 0; i < hero.ArmorsBag.Count(); i++)
            {
                Console.WriteLine($"A{i} - Name: {hero.ArmorsBag[i].Name} / Resell Value: {hero.ArmorsBag[i].ResellValue}");
                sellProducts.Add($"A{i}", hero.ArmorsBag[i]);
            }
            for (var i = 0; i < hero.PotionsBag.Count(); i++)
            {
                Console.WriteLine($"P{i} - Name: {hero.PotionsBag[i].Name} / Resell Value: {hero.PotionsBag[i].ResellValue}");
                sellProducts.Add($"P{i}", hero.PotionsBag[i]);
            }
            if(sellProducts.Values.ToArray().Length == 0)
            {
                Console.WriteLine("You don't have any item in your bag.");
                Menu();
            }else
            {
                Console.WriteLine("Sell item or return to menu");
                Console.WriteLine("If you want to sell item, type the s");
                Console.WriteLine("If you want to return to menu, type the r");

                var choose = Console.ReadLine();
                if (choose == "s")
                {
                    Buy();
                }
                else if (choose == "r")
                {
                    Menu();
                }
                else
                {
                    Console.WriteLine("You type wrong letter. Please enter correct letter.");
                    Console.WriteLine("");
                    Menu();
                }
            }
        }

        public void Sell()
        {
            Console.WriteLine("Choose the item number ex) W0, W1");
            var choice = Console.ReadLine();
            if (choice.Substring(0, 1) == "W")
            {
                var weapon = (Weapon)buyProducts[choice];
                if(weapon.OriginalValue <= hero.Gold)
                {
                    hero.Gold = hero.Gold - weapon.OriginalValue;
                    hero.WeaponsBag.Add(weapon);
                    Console.WriteLine($"You bought the {weapon.Name} for {weapon.OriginalValue} gold.");
                    Menu();
                }
                else
                {
                    Console.WriteLine("You don't have enough gold to buy this item.");
                    Menu();
                }
                
            }
            else if (choice.Substring(0, 1) == "A")
            {
                var armor = (Armor)buyProducts[choice];
                if(armor.OriginalValue <= hero.Gold)
                {
                    hero.Gold = hero.Gold - armor.OriginalValue;
                    hero.ArmorsBag.Add(armor);
                    Console.WriteLine($"You bought the {armor.Name} for {armor.OriginalValue} gold.");
                    Menu();
                }
                else
                {
                    Console.WriteLine("You don't have enough gold to buy this item.");
                    Menu();
                }
            }
            else if (choice.Substring(0, 1) == "P")
            {
                var potion = (Potion)buyProducts[choice];
                if (potion.OriginalValue <= hero.Gold)
                {
                    hero.Gold = hero.Gold - potion.OriginalValue;
                    hero.PotionsBag.Add(potion);
                    Console.WriteLine($"You bought the {potion.Name} for {potion.OriginalValue} gold.");
                    Menu();
                }
                else
                {
                    Console.WriteLine("You don't have enough gold to buy this item.");
                    Menu();
                }
            }
            else
            {
                Console.WriteLine("Type the correct Item name.");
                Menu();
            }
        }

        public void Buy()
        {
            if(sellProducts.Values.ToArray().Length == 0)
            {
                Console.WriteLine("You don't have any item in your bag");
                Menu();
            }
            else
            {
                Console.WriteLine("Choose the item number ex) W0, W1");
                var choice = Console.ReadLine();
                if (choice.Substring(0, 1) == "W")
                {
                    var weapon = (Weapon)sellProducts[choice];
                    hero.Gold = hero.Gold + weapon.ResellValue;
                    hero.WeaponsBag.Remove(weapon);
                    Console.WriteLine($"You sold the {weapon.Name} for {weapon.ResellValue} gold.");
                    Menu();
                }
                else if (choice.Substring(0, 1) == "A")
                {
                    var armor = (Armor)sellProducts[choice];
                    hero.Gold = hero.Gold + armor.ResellValue;
                    hero.ArmorsBag.Remove(armor);
                    Console.WriteLine($"You sold the {armor.Name} for {armor.ResellValue} gold.");
                    Menu();
                }
                else if (choice.Substring(0, 1) == "P")
                {
                    var potion = (Potion)sellProducts[choice];
                    hero.Gold = hero.Gold + potion.ResellValue;
                    hero.PotionsBag.Remove(potion);
                    Console.WriteLine($"You sold the {potion.Name} for {potion.ResellValue} gold.");
                    Menu();
                }
                else
                {
                    Console.WriteLine("Type the correct Item name.");
                    Menu();
                }
            }
        }
    }
}
