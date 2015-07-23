Refactoring Documentation for Project “Minesweeper-1”
------------------------------------------------------
This document describes the steps in the refactoring of the team project "Minesweeper-1" 
in the Telerik Academy JavaScript UI & DOM course 2015

------------------------------------------------------
1. Redesigned the project structure: Team "Minesweeper-1"
	- Renamed the namespace `Mini` to `Minesweeper`
	- Renamed the class `Команда.cs` to `ConsoleInputProvider.cs`
	- Created a namespace `Minesweeper.InputProviders`
	- Moved the class `ConsoleInputProvider.cs` to the namespace `Minesweeper.InputProviders`
	- Created a namespace `Minesweeper.InputProviders.Contracts`
	- Created an interface `IInputProvider.cs` in the namespace `Minesweeper.InputProviders.Contracts` with a method `Read()`

2. Reformatted the source code:
    Generally:
	- Removed all unnecessary `using` directives
	- Moved all `using` directives inside of the `namespace`s
	- Removed all unnecessary whitespaces
	- Removed all inadequate comments

    In the class `ConsoleInputProvider.cs`:
	- Removed the `static` modifier from the class
	- Now implements interface `IInputProvider`
	- Created an empty constructor that takes no parameters
	- Deleted all the rest of the logic inside and moved it to the class `Engine.cs` (`Програма.cs` but must be created separately)

    In the class `Engine.cs` (`Програма.cs` but must be created separately):
	- created variables `inputProvider`...
	- created methods `EndGame()`, `Restart()`, `HandleCommand()`, `ShowTopScores()`, `DispatchCommand()`
