using System.Linq;
using GameLogic;
using GameLogic.GameGenerator;
using OpenTK;
namespace TheseusGame
{
     
    using System;
    public static class StartUp
    {
        public static void Main()
        {
            GameTeseus window = new GameTeseus(640, 480);
            window.Run();
        }

        private static void TestTopScores()
        {
            var result = TopScores.Show().ToList();
            result.ForEach(x=>
            {
                Console.WriteLine(x);
            });
            PrintLine();

            TopScores.CheckScore("Pesho", 1000);
            TopScores.CheckScore("Ivan", 50);
            TopScores.CheckScore("Gosho", 3000);
            result = TopScores.Show().ToList();
            result.ForEach(x => Console.WriteLine(x));
            PrintLine();

            TopScores.Clear();
            result = TopScores.Show().ToList();
            result.ForEach(x => Console.WriteLine(x));
        }

        private static void PrintLine() => Console.WriteLine(new string('-', 40));
    }
}
