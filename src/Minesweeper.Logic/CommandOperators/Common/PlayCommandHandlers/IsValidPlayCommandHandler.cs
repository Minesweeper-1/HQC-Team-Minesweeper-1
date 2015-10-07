namespace Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers
{
    using System;
    using System.Collections.Generic;

    using Boards.Contracts;
    using Contracts;
    using Logic.Common;

    public class IsValidPlayCommandHandler : PlayCommandHandler
    {
        public override void HandleRequest(string command, IBoard board)
        {
            bool isInvalid = false;
            int row = -1;
            int col = -1;

            string trimmedCommand = command.Trim();
            string[] commandComponents = trimmedCommand.Split(GlobalConstants.CommandParametersDivider);
            if (commandComponents.Length < 2 || commandComponents.Length > 2)
            {
                isInvalid = true;
            }
            else
            {
                bool rowIsNumeric = int.TryParse(commandComponents[0], out row);
                bool colIsNumeric = int.TryParse(commandComponents[1], out col);

                if (!(rowIsNumeric && colIsNumeric))
                {
                    isInvalid = true;
                }
            }

            if (isInvalid)
            {
                board.ChangeBoardState(new Notification(GlobalMessages.InvalidCommand, BoardState.Pending));
            }
            else if (this.Successor != null)
            {
                Console.WriteLine(board.Cells[row, col].Content.Value);
                IList<Coordinate> neighbours = new List<Coordinate>();
                neighbours.Add(new Coordinate(0, 1));
                neighbours.Add(new Coordinate(1, 0));
                neighbours.Add(new Coordinate(1, 1));
                neighbours.Add(new Coordinate(0, -1));
                neighbours.Add(new Coordinate(-1, 0));
                neighbours.Add(new Coordinate(1, -1));
                neighbours.Add(new Coordinate(-1, 1));
                neighbours.Add(new Coordinate(-1, -1));

                if (board.Cells[row, col].Content.Value == 0)
                {
                    foreach (var neighbour in neighbours)
                    {
                        var curRow = row + neighbour.Row;
                        var curCol = col + neighbour.Col;
                        // Console.WriteLine($"{curRow} {curCol}");
                        // var newCommand = curRow + " " + curCol;
                        this.Successor.HandleRequest(curRow, curCol, board);
                    }
                }
                this.Successor.HandleRequest(row, col, board);
            }
        }
    }
}
