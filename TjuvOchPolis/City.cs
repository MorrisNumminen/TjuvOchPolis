using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    class City
    {
        private readonly char _emptyPos = '.';
        private int _sizeX;
        private int _sizeY;
        private char[,] _cityBoard;
        private List<Person> _players = new List<Person>();
        public int robedCitizens = 0;
        public int jailedThiefes = 0;

        public City(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            _cityBoard = new char[sizeY, sizeX ];
            ClearBoard();
        }

        private void ClearBoard()
        {
            for (int y = 0; y < _sizeY; y++)
            {
                for (int x = 0; x < _sizeY; x++)
                {
                    _cityBoard[y, x] = '.';
                }
            }
        }

        public void PrintCityBoard()
        {
            ClearBoard();
            UppdateCityBoard();
            Console.Clear();
            for (int y = 0; y < _sizeY; y++)
            {
                for (int x = 0; x < _sizeX; x++)
                {
                    Console.Write(_cityBoard[y,x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Robbed: {robedCitizens}");
            Console.WriteLine($"Jailed: {jailedThiefes}");
            CheckIfPlayerIsOnTheSamePos();
        } 

        public void AddPlayer(Person p)
        {
            while (_cityBoard[p.PosY, p.PosX] != _emptyPos)
            {
                p.GeneratePosition();
            }
            _players.Add(p);
        }

        public void AddPlayers(int citizen, int police, int theif)
        {
            for (int i = 0; i < citizen; i++)
            {
                _players.Add(new Citizen(_sizeX, _sizeY));
            }
            for (int i = 0; i < police; i++)
            {
                _players.Add(new Police(_sizeX, _sizeY));
            }
            for (int i = 0; i < theif; i++)
            {
                _players.Add(new Theif(_sizeX, _sizeY));
            }
        }

        public void MovePlayers()
        {
            foreach (var player in _players)
            {
                player.Move();
            }            
        }

        public void UppdateCityBoard()
        {
            foreach ( var player in _players)
            {
                _cityBoard[player.PosY, player.PosX] = player.GetChareter();
            }
        }

        public void CheckIfPlayerIsOnTheSamePos()
        {
            for (int y = 0; y < _sizeY; y++)
            {
                for (int x = 0; x < _sizeY; x++)
                {
                    if (_cityBoard[y, x] == _emptyPos)
                    {
                        continue;
                    }
                    else
                    {
                        //get all players att the current position in a list.
                        var posList = new List<Person>();
                        foreach (var p in _players)
                        {
                            if (p.PosX == x && p.PosY == y)
                            {
                                posList.Add(p);
                            }
                        }
                        //if only one player att the position, continue.
                        if(posList.Count == 1)
                        {
                            continue;
                        }
                        //If more than one player, do something based on which playerType is on the position.
                        else
                        {
                            for (int i = 0; i < posList.Count; i++)
                            {
                                if(posList[i] is Police)
                                {
                                   jailedThiefes += posList[i].Interact(posList);
                                }
                                if(posList[i] is Theif)
                                {
                                    robedCitizens += posList[i].Interact(posList);
                                    Console.WriteLine("-----");
                                }
                                
                            }
                            for (int i = 0; i < _players.Count; i++)
                            {
                                if(_players[i].Inventory == 0)
                                {
                                    if(_players[i] is Police)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        _players.Remove(_players[i]);
                                    }
                                        
                                    
                                    
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
