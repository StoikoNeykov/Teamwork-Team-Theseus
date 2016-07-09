namespace GameLogic.Engine
{
    using System;

    using Enumerations;
    using Interfaces;

    public class Engine : IEngine
    {
        //                          Up      Right       Down     Left
        private int[,] moves = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };

        public void ExecuteCommand(IField playground, IPlayer player, Commands command)
        {
            var rowChange = moves[(int)command, 0];
            var ColChange = moves[(int)command, 1];
            bool IsPosibleMove = ValidateMove(playground, player, rowChange, ColChange);

            switch (command)
            {
                case Commands.MoveUp:
                    break;
                case Commands.MoveRight:
                    break;
                case Commands.MoveDown:
                    break;
                case Commands.MoveLeft:
                    break;

            }
        }

        private bool ValidateMove(IField playground, IPlayer player, int rowChange, int ColChange)
        {
            var newRow = player.Top + rowChange;
            var newCol = player.Left + ColChange;

            if (playground.Matrix[newRow, newCol] == null)
            {
                return true;
            }

            return false;
        }
    }
}
