namespace TeseusGame
{
    using System;
    using System.Windows.Forms;

    using TopScores;

    public static class StartUp
    {
        public static void Main()
        {
            TestTopScores();
        }

        private static void TestTopScores()
        {
            var result = TopScores.Show();
            Console.WriteLine(result);
            PrintLine();

            TopScores.CheckScore("Pesho", 1000);
            TopScores.CheckScore("Ivan", 50);
            TopScores.CheckScore("Gosho", 3000);
            result = TopScores.Show();
            Console.WriteLine(result);

            TopScores.Clear();
            result = TopScores.Show();
            Console.WriteLine(result);
        }

        private static void PrintLine() => Console.WriteLine(new string('-', 40));
    }
}
