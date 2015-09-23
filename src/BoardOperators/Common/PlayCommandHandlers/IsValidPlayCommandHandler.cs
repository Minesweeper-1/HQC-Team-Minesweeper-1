namespace Minesweeper.BoardOperators.Common.PlayCommandHandlers
{
    using global::Minesweeper.Common;
    using Contracts;
    using Boards.Contracts;
    using Renderers.Contracts;
    using System;

    public class IsValidPlayCommandHandler : PlayCommandHandler
    {
        public IsValidPlayCommandHandler()
        {

        }

        public override void HandleRequest(string command, IBoard board, IRenderer renderer)
        {
            bool isInvalid = false;
            int x = -1;
            int y = -1;

            string trimmedCommand = command.Trim();
            string[] commandComponents = trimmedCommand.Split(GlobalConstants.CommandParametersDivider);
            if (commandComponents.Length < 2 || commandComponents.Length > 2)
            {
                isInvalid = true;
            }
            else
            {
                bool xIsNumeric = int.TryParse(commandComponents[0], out x);
                bool yIsNumeric = int.TryParse(commandComponents[1], out y);

                renderer.ClearCurrentConsoleLine();
                if (!(xIsNumeric && yIsNumeric))
                {
                    isInvalid = true;
                }
            }

            if (isInvalid)
            {
                renderer.RenderLine(GlobalMessages.InvalidCommand);
                board.ChangeBoardState(BoardState.Pending);
            }
            else if (this.Successor != null)
            {
                this.Successor.HandleRequest(x, y, board, renderer);
            }
        }
    }
}
