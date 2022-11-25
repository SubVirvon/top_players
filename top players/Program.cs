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
                new Player("Roberto", 92, 24),
            });
            int topPlayersCount = 3;

            database.SortByLevel();

            Console.WriteLine($"Топ {topPlayersCount} по Уровню:");

            database.ShowTop(topPlayersCount);
            database.SortByStrength();

            Console.WriteLine($"\nТоп {topPlayersCount} по Силе:");

            database.ShowTop(topPlayersCount);

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

        public void SortByLevel()
        {
            _players = _players.OrderByDescending(player => player.Level).ToList();
        }

        public void SortByStrength()
        {
            _players = _players.OrderByDescending(player => player.Strength).ToList();
        }

        public void ShowTop(int count)
        {
            if(count > _players.Count)
                count = _players.Count;

            for(int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}.{_players[i].Name}");
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
