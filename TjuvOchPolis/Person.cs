using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    abstract class Person
    {
        private int _citySizeX, _citySizeY;
        public int PosX { get; private set; }
        public int PosY { get; private set; }

        private int DirX { get; set; }
        private int DirY { get; set; }
        public abstract int Inventory { get; set; }

        public Person(int citySizeX, int citySizeY)
        {
            _citySizeX = citySizeX;
            _citySizeY = citySizeY;
            GeneratePosition();
        }

        public void GeneratePosition()
        {
            PosX = new Random().Next(0, _citySizeX);
            PosY = new Random().Next(0, _citySizeY);
        }

        public void Move()
        {
            DirX = new Random().Next(-1, 2);
            DirY = new Random().Next(-1, 2);
;           PosX += DirY;
            PosY += DirX;

            if (PosX >= _citySizeX)
            {
                PosX = 0;
            }
            if (PosX < 0)
            {
                PosX = _citySizeX - 1;
            }

            if (PosY >= _citySizeY)
            {
                PosY = 0;
            }
            if (PosY < 0)
            {
                PosY = _citySizeY - 1;
            }
        }

        abstract public int Interact(List<Person> interactees);
        public abstract char GetChareter();
    }
}
