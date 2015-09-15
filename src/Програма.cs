namespace Minesweeper
{
    using Engine;
    using Boards;
    using Renderers;

    public class Програма
    {
        static void Main()
        {
            var board = new Board();
            var renderer = new ConsoleRenderer();
            var engine = new StandardOnePlayerMinesweepwerEngine(board, renderer);
            engine.Initialize();
        }

        //    static void Main()
        //    {
        //        var inputProvider = new ConsoleInputProvider();

        //        Scoreboard scoreboard = new Scoreboard();
        //        ДайНаново:
        //        bool displayBoard = true;
        //        Board board = new Board();
        //        Console.WriteLine("Welcome to the game “Minesweeper”. Try to reveal all cells without mines. Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
        //        Console.WriteLine();

        //        while (true)
        //        {
        //            if (displayBoard)
        //                board.Display();
        //            displayBoard = true;
        //            Console.Write("Enter row and column: ");

        //            var currentCommand = inputProvider.Read();
        //            DispatchCommand(currentCommand);

        //            // TODO: These lines of code should go to their corresponding methods
        //            // Команда does not exist now
        //            if (!Команда.NeMojesh)
        //            {
        //                if (Команда.IsGetStatistic)// input = Top
        //                {
        //                    scoreboard.Show();
        //                    displayBoard = false;
        //                    Команда.Clear();
        //                    continue;
        //                }
        //                if (Команда.Izlez) // input = Exit
        //                {
        //                    Console.WriteLine("Goodbye!");
        //                    Environment.Exit(0);
        //                }
        //                if (Команда.Nanovo) // Input = Restart
        //                {
        //                    goto ДайНаново;
        //                }

        //                int x = Команда.x;
        //                int y = Команда.y;
        //                if (!board.proverka(x, y) || board.proverka2(x, y))
        //                {
        //                    Console.WriteLine("Illegal move!");
        //                    Console.WriteLine();
        //                    displayBoard = false;
        //                }
        //                else
        //                {
        //                    if (board.proverka3(x, y))
        //                    {
        //                        board.Край(x, y);
        //                        board.Display();
        //                        Console.WriteLine("Booooom! You were killed by a mine. You revealed " + board.RevealedCells + " cells without mines.");
        //                        Console.WriteLine();
        //                        if (board.RevealedCells > scoreboard.MinInTop5() || scoreboard.Count() < 5)
        //                        {
        //                            scoreboard.Add(board.RevealedCells);
        //                        }
        //                        scoreboard.Show();
        //                        goto ДайНаново;
        //                    }
        //                    else
        //                        board.RevealBlock(x, y);
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("Illegal command!");
        //                displayBoard = false;
        //            }
        //        }
        //    }

        //    private static void DispatchCommand(string currentCommand)
        //    {
        //        switch (currentCommand)
        //        {
        //            case "Exit":
        //                EndGame();
        //                break;

        //            case "Top":
        //                ShowTopScores();
        //                break;

        //            case "Restart":
        //                Restart();
        //                break;
        //            default:
        //                HandleCommand(currentCommand);
        //                break;
        //        }
        //    }

        //    private static void HandleCommand(string currentCommand)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    private static void Restart()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    private static void ShowTopScores()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    private static void EndGame()
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
