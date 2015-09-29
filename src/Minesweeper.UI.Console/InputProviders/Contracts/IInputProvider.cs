namespace Minesweeper.UI.Console.InputProviders.Contracts
{
    public interface IInputProvider
    {
        bool IsKeyAvailable { get; }

        string GetLine();

        int GetKeyChar(bool justABool);
    }
}
