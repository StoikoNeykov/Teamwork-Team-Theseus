namespace GameLogic
{
    public class GlobalConstant
    {
        public const double WaxPaperDesity = 0.028;
        public const double BookPaperDensity = 0.026;
        public const double MarbleDensity = 2.8;
        public const double WoodDensity = 0.74;
        public const double SteelDensity = 8.050;
        public const double CrushedStoneDensity = 1.6;
        public const double DiamandDensity = 3.51;
        public const double SolidDensity = 100;
        public const double EmptyDensity = 0;
        public const double PaperDensity = 0.05;

        // Creator constants
        public const int StandarPlaygroundtWidth = 10;
        public const int StandartPlaygroundHeight = 20;
        public const int SpecialFieldWidth = 4;
        public const int SpecialFieldHeight = 4;

        // LevelMaker constants
        // WARNING: If too many figures been set endless loop is posible!!! 
        public const int figuresOnThePlayground = 15;
        public const int maxTriesToPlaceFigure = 50;

        public const string TopScoresFileName = @"TopScore.dat";
        public const int Tops = 10;

        public const string WrongCreationError = "Cannot use that method for that creation!";
        public const string WrongCommandError = "Wrong command  dude!";
    }
}
