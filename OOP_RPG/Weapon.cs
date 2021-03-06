using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Weapon : Item
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }

        public Weapon(string name, int originalvalue, int resellvalue, int strength) {

            this.Name = name;
            this.Strength = strength;
            this.OriginalValue = originalvalue;
            this.ResellValue = resellvalue;
        }
    }
}