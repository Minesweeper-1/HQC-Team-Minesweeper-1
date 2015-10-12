Refactoring Documentation for Project “Minesweeper-1”
------------------------------------------------------
This document describes the steps in the refactoring of the team project "Minesweeper-1" 
in the Telerik Academy High-Quality Code Course 2015

------------------------------------------------------
1. Redesigned the project structure: Team "Minesweeper-1"
	- Created a project `Minesweeper.Logic`;
	- Created a namespace `UI`:
		- Created a project `Minesweeper.UI.Console`
			- Introduced a class `ConsoleInputProvider` implementing the `IInputPovider` interface from the logic, which uses the Console to receive input - menu item selection, cell selection, board and game interaction
			- Introduced a class `ConsoleRenderer` implementing the `IRenderer` interface from the logic, which uses the Console to write output - the board, scoreboard and game messages
			- Introduced a class `ConsoleMenuHandler` which is a console-based class used for rendering a menu and introducing menu item-selecting logic for better UX
			- Introduced a class `StandardOnePlayerMinesweeperEngine` which utilizes the `StandardGameInitializationStrategy` by filling the board using a concrete step-by-step algorithm
		- Created a project `Minesweeper.UI.WPF`
			- For now it is just an example of how easy it can be implementing entirely different means of receiving input and sending output
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
	- Refactored all one-line block statements
	- Added angle brackets to one-line block statements
	- Removed the bad `goto`
	- Abstracted as much as possible all class references
	- Separated the class logic in accordance with Single Responsibility Principle
	- All classes now conform to the Open/Closed Principle
	- Inheritance chains conform to the Liskov Substitution Principle
	- All interfaces conform to the Interface Segregation Principle
	- Applied Dependency Inversion to the complex classes which have more or less a lot of class dependencies
	- Character casing: variables and fields made camelCase; types and methods made PascalCase
	- Formatted all other elements of the source code according to the best practices introduced in the course “High-Quality Programming Code”.
	- Removed **90%** of the initial logic - impossible to split the spaghetti 
	
	The console rendering class:
	- Changed the rendering symbols
	- Added color to the rendered symbols
	- Added more sophisticated board borders
	- Replaced all inadequate game messages with better

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