Refactoring Documentation for Project “Minesweeper-1”
------------------------------------------------------
This document describes the steps in the refactoring of the team project "Minesweeper-1" 
in the Telerik Academy JavaScript UI & DOM course 2015

------------------------------------------------------
1. Redesigned the project structure: Team "Minesweeper-1"
	- Created a project Minesweeper.Logic;
	- Created a namespace UI:
		- Created a project Minesweeper.UI.Console;
		- Created a project Minesweeper.UI.WPF;
	- Renamed the namespace `Mini` to `Minesweeper.Logic`
	- Renamed the class `Команда.cs` to `ConsoleInputProvider.cs`
	- Renamed the class `Програма.cs` to `StandardMinesweeperEngine.cs`
	- Created a namespace `Minesweeper.InputProviders`
	- Moved the class `ConsoleInputProvider.cs` to the namespace `Minesweeper.InputProviders`
	- Created a namespace `Minesweeper.InputProviders.Contracts`
	- Created an interface `IInputProvider.cs` in the namespace `Minesweeper.InputProviders.Contracts` with a method `Read()`

2. Reformatted the source code:

    Generally:
	- Removed all unnecessary `using` directives
	- Moved all `using` directives inside the `namespace`s
	- Removed all unnecessary whitespace
	- Removed all inadequate comments

    In the class `ConsoleInputProvider.cs`:
	- Removed the `static` modifier from the class
	- Now implements interface `IInputProvider`
	- Created an empty constructor that takes no parameters
	- Deleted all the rest of the logic inside and moved it to the class `Engine.cs` (`Програма.cs` but must be created separately)

    In the class `Engine.cs` (`Програма.cs` but must be created separately):
	- created variables `inputProvider`...
	- created methods `EndGame()`, `Restart()`, `HandleCommand()`, `ShowTopScores()`, `DispatchCommand()`

3. Implemented the following patterns:
   - **Creational**: 
	   - Singleton: The façade
	   - Simple Factory: `ContentFactory` class
	   - Fluent Interface: The `Board` class
	   - Lazy Initialization: The façade
   - **Structural**: 
	   - Façade: The `Game` class
	   - Bridge: Rendering and input providing logic is abstracted through interfaces
	   - Adapter: For the NetEncryptionLibrary
   - **Behavioral**: 
	   - Strategy: The board initialization with empty cells and bombs
	   - Observer: The Engine observes the state of the board
	   - Command: The input is being translated to engine instructions by being processed by their corresponding commands
	   - Chain of Responsibility: The different stages of "reading" the play command - is the command valid, is it inside the board, is it a bomb, and finally - reveal the cell