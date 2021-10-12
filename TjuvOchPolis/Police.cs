using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    class Police : Person
    {
        public override int Inventory { get; set; }
        public Police(int citySizeX, int citySizeY) : base(citySizeX, citySizeY)
        {
            Inventory = 0;
        }

        override public char GetChareter()
        {
            return 'P';
        }

        override public int Interact(List<Person> interactees)
        {
            int jaliedCounter = 0;
            for (int i = 0; i < interactees.Count; i++)
            {
                if(interactees[i] is Theif)
                {
                    Theif t = ((Theif)interactees[i]);
                    Inventory += t.Inventory;
                    t.Inventory = 0;
                    jaliedCounter++;
                }
            }

            return jaliedCounter;
        }
    }
}
