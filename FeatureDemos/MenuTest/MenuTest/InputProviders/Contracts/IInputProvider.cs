namespace MenuTest.InputProviders.Contracts
{
    public interface IInputProvider
    {
        bool IsKeyAvailable { get; }

        int GetKeyChar();

        int GetKeyChar(bool justABool);
    }
}
