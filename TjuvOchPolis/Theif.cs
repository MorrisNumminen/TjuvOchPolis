using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    class Theif : Person
    {
        public override int Inventory { get; set; }
        public Theif(int citySizeX, int citySizeY) : base(citySizeX, citySizeY)
        {
            Inventory = 0;
        }

        override public char GetChareter()
        {
            return 'T';
        }
        override public int Interact(List<Person> interactees)
        {
            var robCounter = 0;
            for (int i = 0; i < interactees.Count; i++)
            {
                if (interactees[i] is Citizen)
                {
                    Citizen c = (Citizen)interactees[i];
                    Inventory += 1;
                    c.Inventory -= 1;
                    robCounter ++;
                }
            }
            return robCounter;
        }
    }
}
