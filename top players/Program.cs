using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace top_players
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database(new List<Player>()
            {
                new Player("мегаНекит", 101, 27),
                new Player("Crisp", 24, 5),
                new Player("fufak", 103, 26),
                new Player("Svin", 57, 19),
                new Player("Миха", 80, 23),
                new Player("Степа", 12, 2),
                new Player("Газкул", 114, 23),
                new Player("Lisa", 31, 7),
                new Player("MiniSpirt", 109, 29),
                new Player("Stef", 110, 28),
                new Player("Киря", 95, 24),
                new Player("Roberto", 92, 24)
            });
            int topPlayersCount = 3;

            database.ShowTopByLevel(topPlayersCount);

            Console.WriteLine();

            database.ShowTopByStrength(topPlayersCount);

            Console.ReadKey();
        }
    }

    class Database
    {
        private List<Player> _players;

        public Database(List<Player> players)
        {
            _players = players;
        }

        public void ShowTopByLevel(int topPlayersCount)
        {
            Console.WriteLine($"Топ {topPlayersCount} по Уровню:");

            ShowTop(_players.OrderByDescending(player => player.Level).Take(topPlayersCount).ToList());
        }

        public void ShowTopByStrength(int topPlayersCount)
        {
            Console.WriteLine($"Топ {topPlayersCount} по Силе:");

            ShowTop(_players.OrderByDescending(player => player.Strength).Take(topPlayersCount).ToList());
        }

        public void ShowTop(List<Player> top)
        {
            for(int i = 0; i < top.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{top[i].Name}");
            }
        }
    }


    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Strength { get; private set; }

        public Player(string name, int level, int strength)
        {
            Name = name;
            Level = level;
            Strength = strength;
        }
    }
}
