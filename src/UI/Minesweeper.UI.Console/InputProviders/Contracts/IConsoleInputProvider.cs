namespace Minesweeper.UI.Console.InputProviders.Contracts
{
    using Logic.InputProviders.Contracts;

    public interface IConsoleInputProvider : IInputProvider
    {
        bool IsKeyAvailable { get; }

        int GetKeyChar(bool justABool);
    }
}
