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
                new Player("Газкул", 114, 29),
            });
            int count = 3;

            database.SortByLevel();

            Console.WriteLine($"Топ {count} по Уровню:");

            database.ShowTop(count);
            database.SortByStrength();

            Console.WriteLine($"\nТоп {count} по Силе:");

            database.ShowTop(count);

            Console.ReadKey();
        }
    }

    class Database
    {
        private List<Player> _database;

        public Database(List<Player> database)
        {
            _database = database;
        }

        public void SortByLevel()
        {
            _database = _database.OrderByDescending(player => player.Level).ToList();
        }

        public void SortByStrength()
        {
            _database = _database.OrderByDescending(player => player.Strength).ToList();
        }

        public void ShowTop(int count)
        {
            if(count > _database.Count)
                count = _database.Count;

            for(int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}.{_database[i].Name}");
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
