namespace Minesweeper.InputProviders.Contracts
{
    public interface IInputProvider
    {
        bool IsKeyAvailable { get; }

        string GetLine();

        int GetKeyChar(bool justABool);
    }
}
