using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    class Citizen : Person
    {
        public override int Inventory { get; set; }
        public Citizen(int citysizeX, int citySizeY) : base(citysizeX, citySizeY)
        {
            Inventory = 4;
        }

        override public char GetChareter()
        {
            return 'C';
        }
        override public int Interact(List<Person> interactees)
        {
            return 0;
        }

    }
}
