namespace Minesweeper.Logic.CommandOperators.Common.PlayCommandHandlers
{
    using System;

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
                bool colIsNumeric = int.TryParse(("abcdefghijklmnopqrstuvwxyz".IndexOf(commandComponents[1]).ToString()), out col);

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
                this.Successor.HandleRequest(row, col, board);
            }
        }
    }
}
