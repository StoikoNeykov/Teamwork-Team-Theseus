namespace TeseusGame
{
    using System;
    using System.Windows.Forms;
    using System.Linq;
    using GameLogic;
    using static GameLogic.TopScores;

    public static class StartUp
    {
        public static void Main()
        {
            TestTopScores();
        }

        private static void TestTopScores()
        {
            var result = TopScores.Show();
            result.ForEach(x=>
            {
                if (x == null)
                {
                    throw new ArgumentNullException(nameof(x));
                }

                return Console.WriteLine(x);
            });
            PrintLine();

            TopScores.CheckScore("Pesho", 1000);
            TopScores.CheckScore("Ivan", 50);
            TopScores.CheckScore("Gosho", 3000);
            result = TopScores.Show();
            result.ForEach(x => Console.WriteLine(x));
            PrintLine();

            TopScores.Clear();
            result = TopScores.Show();
            result.ForEach(x => Console.WriteLine(x));
        }

        private static void PrintLine() => Console.WriteLine(new string('-', 40));
    }
}
