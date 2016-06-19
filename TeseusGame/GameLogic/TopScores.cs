using System;
using System.IO;
using System.Text;

namespace GameLogic
{
    /// <summary>
    /// Do not allow spaces in name !
    /// </summary>
    public static class TopScores
    {
        private const int tops = 10;

        #region public

        public static string Show()
        {
            var scores = LoadCurentBest();
            var builder = new StringBuilder();
            string name = string.Empty;
            int value;
            var interval = 1;
            for (int i = 0; i < tops; i++)
            {
                if (i == 9 || i == 99)
                {
                    interval++;
                }
                var splited = scores[i]
                            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                name = splited[0];
                value = int.Parse(splited[1]);
                builder.AppendLine(string.Format("{0}. {1}  {2}", i + 1, name.PadRight(16 - interval, ' '), value.ToString().PadLeft(10, ' ')));
            }

            return builder.ToString();
        }

        public static void CheckScore(string name, int value)
        {
            var scores = LoadCurentBest();
            for (int i = 0; i < tops; i++)
            {
                var splited = scores[i]
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var scoreName = splited[0];
                var scoreValue = int.Parse(splited[1]);
                if (value > scoreValue)
                {
                    AddScore(scores, name, value, i);
                    UpdateCurentBest(scores);
                    break;
                }
            }
        }

        public static void Clear()
        {
            UpdateCurentBest(GetHardcoded());
        }

        #endregion

        #region private
        private static void AddScore(string[] scores, string name, int value, int position)
        {
            for (int i = tops - 1; i > position; i--)
            {
                scores[i] = scores[i - 1];
            }

            scores[position] = string.Format($"{name} {value}");
        }

        private static void UpdateCurentBest(string[] scores)
        {
            using (var writer = new StreamWriter("TopScore.dat", false))
            {
                foreach (var score in scores)
                {
                    writer.WriteLine(score);
                }
            }
        }

        private static string[] LoadCurentBest()
        {
            if (!File.Exists("TopScore.dat"))
            {
                UpdateCurentBest(GetHardcoded());
            }

            var result = new string[tops];
            using (var reader = new StreamReader("TopScore.dat"))
            {
                for (int i = 0; i < tops; i++)
                {
                    result[i] = reader.ReadLine() ?? "NoName 0";
                }
            }

            return result;
        }

        private static string[] GetHardcoded()
        {
            var result = new string[tops];
            for (int i = 0; i < tops; i++)
            {
                result[i] = "NoName 0";
            }

            return result;
        }
    }
    #endregion
}
