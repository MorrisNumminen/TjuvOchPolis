using System;

namespace TjuvOchPolis
{
    class Program
    {
        static void Main(string[] args)
        {
            int xSize = 3, ySize = 3;
            var city = new City(xSize, ySize);
            city.PrintCityBoard();
            city.AddPlayers(1, 0, 1);

            for (int i = 0; i < 20; i++)
            {
                city.MovePlayers();
                city.PrintCityBoard();
                Console.ReadLine();
            }
        }
    }
}
