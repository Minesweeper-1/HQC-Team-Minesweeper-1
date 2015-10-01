namespace Minesweeper.Logic.DifficultyCommands
{
    using System.Linq;
    
    using Common.Utils;
    using Contracts;

    using Minesweeper.Logic.Boards;

    public class ExpertMode : IGameMode
    {
        public string Value { get; } = nameof(ExpertMode).SplitByUpperCase().First();

        public IGameMode GetNext() => new BeginnerMode();

        public IGameMode GetPrevious() => new IntermediateMode();

        public BoardSettings Settings => new HardBoardSettings();
    }
}
