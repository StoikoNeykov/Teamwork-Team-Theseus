using System;

namespace GameLogic
{
    /// <summary>
    /// Do not allow spaces in name !
    /// </summary>
    public static class TopScores
    {
        public static string[] Show()
        {
            var scores = DataTransfer.LoadCurentBest();
            var arr = new string[GlobalConstant.Tops];
            string name = string.Empty;
            int value;
            var interval = 1;
            for (int i = 0; i < GlobalConstant.Tops; i++)
            {
                if (i == 9 || i == 99)
                {
                    interval+=2;
                }
                var splited = scores[i]
                            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                name = splited[0];
                value = int.Parse(splited[1]);
                arr[i] = (string.Format("{0}. {1}  {2}", i + 1, name.PadRight(16 - interval, ' '), value.ToString().PadLeft(10, ' ')));
            }

            return arr;
        }

        public static void CheckScore(string name, int value)
        {
            var scores = DataTransfer.LoadCurentBest();
            for (int i = 0; i < GlobalConstant.Tops; i++)
            {
                var splited = scores[i]
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var scoreName = splited[0];
                var scoreValue = int.Parse(splited[1]);
                if (value > scoreValue)
                {
                    AddScore(scores, name, value, i);
                    DataTransfer.UpdateCurentBest(scores);
                    break;
                }
            }
        }

        public static void Clear()
        {
            DataTransfer.UpdateCurentBest(DataTransfer.GetHardcoded());
        }


        private static void AddScore(string[] scores, string name, int value, int position)
        {
            for (int i = GlobalConstant.Tops - 1; i > position; i--)
            {
                scores[i] = scores[i - 1];
            }

            scores[position] = string.Format($"{name} {value}");
        }

    }
}
