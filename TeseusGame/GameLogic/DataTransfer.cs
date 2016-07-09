namespace GameLogic
{
    using System.IO;

    public static class DataTransfer
    {


        internal static void UpdateCurentBest(string[] scores)
        {
            using (var writer = new StreamWriter(GlobalConstant.TopScoresFileName, false))
            {
                foreach (var score in scores)
                {
                    writer.WriteLine(score);
                }
            }
        }

        internal static string[] LoadCurentBest()
        {
            if (!File.Exists(GlobalConstant.TopScoresFileName))
            {
                UpdateCurentBest(GetHardcoded());
            }

            var result = new string[GlobalConstant.Tops];
            using (var reader = new StreamReader(GlobalConstant.TopScoresFileName))
            {
                for (int i = 0; i < GlobalConstant.Tops; i++)
                {
                    result[i] = reader.ReadLine() ?? "NoName 0";
                }
            }

            return result;
        }

        internal static string[] GetHardcoded()
        {
            var result = new string[GlobalConstant.Tops];
            for (int i = 0; i < GlobalConstant.Tops; i++)
            {
                result[i] = "NoName 0";
            }

            return result;
        }
    }
}
