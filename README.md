Refactoring Documentation for Project “Minesweeper-1”
------------------------------------------------------
This document describes the steps in the refactoring of the team project "Minesweeper-1" 
in the Telerik Academy High-Quality Code Course 2015

------------------------------------------------------
1. Redesigned the project structure: Team "Minesweeper-1"
	- Created a project Minesweeper.Logic;
	- Created a namespace UI:
		- Created a project Minesweeper.UI.Console;
		- Created a project Minesweeper.UI.WPF;
	- Renamed the namespace `Mini` to `Minesweeper.Logic`
	- Introduced the following namespaces:
		- `Minesweeper.Logic.Boards`, containing the Board object and settings definitions
		- `Minesweeper.Logic.Cells`, containing the Cell object definitions
		- `Minesweeper.Logic.CommandOperators`, containing Play, ShowScoreboard, Exit and Restart command handling definitions
		- `Minesweeper.Logic.Common`, containing common utils, constants and enumerations used in the entire Logic namespace
		- `Minesweeper.Logic.Contents`, containg  the cell contents and cell contents factory definitions
		- `Minesweeper.Logic.Data`, containing the text file with the soreboard entries
		- `Minesweeper.Logic.DataManagers`, containg JSON parsing and serializing logic, as well as encryption/decryption and file reading and writing logic
		- `Minesweeper.Logic.DifficultyCommands`, containing definitions of chained game modes with successors and predecessors aimed at providing an interface for implementing menu logic in some UI form
		- `Minesweeper.Logic.Engines`, containing the interfaces for an engine operating the different modules
		- `Minesweeper.Logic.InputProviders`, containing the interfaces for an input providing module logic
		- `Minesweeper.Logic.Players`, containing the Player object definitions
		- `Minesweeper.Logic.Renderers`, containing the interfaces for a rendering module logic
		- `Minesweeper.Logic.Scoreboards`, containing the Scoreboard object definitions

2. Reformatted the source code:

    Generally:
	- Removed all unnecessary `using` directives
	- Moved all `using` directives inside the `namespace`s
	- Removed all unnecessary whitespace
	- Removed all inadequate comments
	- Removed all bad statics from the classes
	- Abstracted as much as possible all class references
	- Separated the class logic in accordance with SRP

3. Implemented the following patterns:
   - **Creational**: 
	   - Singleton: The façade
	   - Simple Factory: `ContentFactory` class, producing Cell Content
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