using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Potion
    {
        public int HP { get; set; }
        public string Name { get; set; }

        public Potion(int hp, string name)
        {
            this.HP = hp;
            this.Name = name;
        }
    }
}
