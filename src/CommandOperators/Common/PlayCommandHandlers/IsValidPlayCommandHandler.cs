namespace Minesweeper.CommandOperators.Common.PlayCommandHandlers
{
    using Boards.Contracts;
    using Contracts;
    using Minesweeper.Common;
    using Renderers.Contracts;

    public class IsValidPlayCommandHandler : PlayCommandHandler
    {
        public override void HandleRequest(string command, IBoard board, IRenderer renderer)
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

                renderer.ClearCurrentLine();
                if (!(rowIsNumeric && colIsNumeric))
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
                this.Successor.HandleRequest(row, col, board, renderer);
            }
        }
    }
}
