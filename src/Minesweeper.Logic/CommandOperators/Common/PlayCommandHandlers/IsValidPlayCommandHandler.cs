namespace Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers
{
    using System.Collections.Generic;

    using Boards.Contracts;
    using Contracts;
    using Logic.Common;

    /// <summary>
    /// A class that checks the validity of the command
    /// </summary>
    public class IsValidPlayCommandHandler : PlayCommandHandler
    {
        private readonly ICollection<Coordinate> visited = new List<Coordinate>();

        /// <summary>
        /// A method that checks whether the command is valid and deals with it or calls its successor to handle the request
        /// </summary>
        /// <param name="command">String with the incoming command</param>
        /// <param name="board">The current playing board</param>
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
                if (board.IsInsideBoard(row, col) && board.Cells[row, col].Content.Value == 0)
                {
                    this.Accumulate(row, col, board);

                    // Reset list for next play command
                    this.visited.Clear();
                }
                else
                {
                    this.Successor.HandleRequest(row, col, board);
                }
            }
        }

        private void Accumulate(int row, int col, IBoard board)
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    var coordinate = new Coordinate(i, j);
                    if (this.visited.Contains(coordinate))
                    {
                        continue;
                    }

                    if (board.IsInsideBoard(i, j))
                    {
                        if (board.Cells[i, j].Content.Value == 0)
                        {
                            this.visited.Add(coordinate);
                            this.Successor.HandleRequest(i, j, board);
                            this.Accumulate(i, j, board);
                        }
                    }
                }
            }
        }
    }
}
