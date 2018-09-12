using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Armor : Item
    {
        public string Name { get; set; }
        public int Defense { get; set; }
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }

        public Armor(string name, int defense, int originalvalue, int resellvalue) {
            this.Name = name;
            this.Defense = defense;
            this.OriginalValue = originalvalue;
            this.ResellValue = resellvalue;
        }
    }
}