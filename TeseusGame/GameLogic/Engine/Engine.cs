namespace GameLogic.Engine
{
    using System;

    using Enumerations;
    using Interfaces;

    public class Engine : IEngine
    {
        //                          Up      Right       Down     Left
        private int[,] moves = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };


        public virtual void ExecuteCommand(IField playground, IField specialField, IPlayer player, string command)
        {
            //commands is still not ready so I leave that ugly texts like that just for now! 
            switch (command)
            {
                case "moveup":
                    ExecuteMove(playground, player, Commands.MoveUp);
                    break;
                case "moveright":
                    ExecuteMove(playground, player, Commands.MoveRight);
                    break;
                case "movedown":
                    ExecuteMove(playground, player, Commands.MoveDown);
                    break;
                case "moveleft":
                    ExecuteMove(playground, player, Commands.MoveLeft);
                    break;
                case "show":
                    ExecuteNotMovingCommand(playground, specialField, player, Commands.Show);
                    break;
                case "changeblockofview":
                    break;
                default:
                    throw new InvalidOperationException(GlobalConstant.WrongCommandError);
            }
        }

        public virtual void ExecuteMove(IField playground, IPlayer player, Commands command)
        {
            var rowChange = moves[(int)command, 0];
            var ColChange = moves[(int)command, 1];
            var newRow = player.Top + rowChange;
            var newCol = player.Left + ColChange;

            bool IsPosibleMove = ValidateMove(playground, player, newRow, newCol);

            switch (command)
            {
                case Commands.MoveUp:
                    player.ViewDirection = Directions.Up;
                    break;
                case Commands.MoveRight:
                    player.ViewDirection = Directions.Right;
                    break;
                case Commands.MoveDown:
                    player.ViewDirection = Directions.Down;
                    break;
                case Commands.MoveLeft:
                    player.ViewDirection = Directions.Left;
                    break;
                default:
                    break;
            }

            if (IsPosibleMove)
            {
                playground.Matrix[player.Top, player.Left] = null;
                playground.Matrix[newRow, newCol] = player;
                player.Top = newRow;
                player.Left = newCol;
            }
            // else no needed for now !
        }

        public virtual bool ValidateMove(IField playground, IPlayer player, int newRow, int newCol)
        {
            if (playground.Matrix[newRow, newCol] == null)
            {
                return true;
            }

            return false;
        }

        public virtual void ExecuteNotMovingCommand(IField playground, IField specialField, IPlayer player, Commands command)
        {
            switch (command)
            {
                case Commands.Show:
                    ShowFigureInSpecialField(playground, specialField, player);
                    break;
                default:
                    throw new InvalidOperationException(GlobalConstant.WrongCommandError);
            }
        }

        public virtual void ShowFigureInSpecialField(IField playground, IField specialField, IPlayer player)
        {
            var figureRow = player.Top + moves[(int)player.ViewDirection, 0];
            var figureCol = player.Left + moves[(int)player.ViewDirection, 1];
            var figure = (IFigure)playground.Matrix[figureRow, figureCol];

            // I know I can use figure.Width and figure.Height but Block.Getshape() !
            // Well ... happens sometimes 
            var rows = figure.Shape.GetLength(0);
            var cols = figure.Shape.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (figure.Shape[row, col])
                    {
                        specialField.Matrix[row, col] = figure;
                    }
                }
            }
        }
    }
}
