// <copyright file="IsValidPlayCommandHandlerTests.cs" company="Team Minesweeper-1">
// Copyright (c) The team. All rights reserved.
// </copyright>
namespace Minesweeper.Logic.Tests.CommandOperators.Common.PlayCommandHandlers
{
    using System.Collections.Generic;

    using Logic.Boards;
    using Logic.Boards.Contracts;
    using Logic.Boards.Settings;
    using Logic.Cells;
    using Logic.CommandOperators.Common.PlayCommandHandlers;
    using Logic.Common;
    using Logic.Contents;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// A class containing tests for the IsValidCommandHandler functionality
    /// </summary>
    [TestClass]
    public class IsValidPlayCommandHandlerTests
    {
        /// <summary>
        /// Test checking whether the handler recognized a valid command
        /// </summary>
        [TestMethod]
        public void IsValidHandleRequestShouldRecogniseAValidCommand()
        {
            var testHandler = new IsValidPlayCommandHandler();
            testHandler.HandleRequest(command: "1 1", board: new Board(new EasyBoardSettings(), new List<IBoardObserver>()));
            Assert.AreEqual(expected: false, actual: testHandler.IsInvalid);
        }

        /// <summary>
        /// Test checking whether the handler recognizes an invalid command
        /// </summary>
        [TestMethod]
        public void IsValidHandleRequestShouldRecogniseAnInvalidCommand()
        {
            var testHandler = new IsValidPlayCommandHandler();
            var testBoard = new Board(new EasyBoardSettings(), new List<IBoardObserver>());
            testHandler.HandleRequest(command: "a a", board: testBoard);
            Assert.AreEqual(expected: true, actual: testHandler.IsInvalid);
            Assert.AreEqual(BoardState.Pending, testBoard.BoardState);
        }

        /// <summary>
        /// Test checking whether the handler handles the request if the cell is valid
        /// </summary>
        [TestMethod]
        public void IsValidPlayShouldHandleTheRequestIfTheCellIsValid()
        {
            var testHandler = new IsValidPlayCommandHandler();
            var testBoard = new Board(new EasyBoardSettings(), new List<IBoardObserver>());
            testHandler.SetSuccessor(new IsInsideBoardHandler());
            testBoard.Cells[0, 0] = new CellContext();
            testBoard.Cells[0, 0].Content = new EmptyContent();
            testBoard.Cells[0, 0].Content.Value = 0;
            testBoard.Cells[0, 0].State = CellState.Sealed;
            testBoard.Cells[0, 1] = new CellContext();
            testBoard.Cells[0, 1].Content = new EmptyContent();
            testBoard.Cells[0, 1].Content.Value = 1;
            testBoard.Cells[0, 1].State = CellState.Sealed;
            testBoard.Cells[1, 0] = new CellContext();
            testBoard.Cells[1, 0].Content = new EmptyContent();
            testBoard.Cells[1, 0].Content.Value = 1;
            testBoard.Cells[1, 0].State = CellState.Sealed;
            testBoard.Cells[1, 1] = new CellContext();
            testBoard.Cells[1, 1].Content = new EmptyContent();
            testBoard.Cells[1, 1].Content.Value = 2;
            testBoard.Cells[1, 1].State = CellState.Sealed;
            testHandler.HandleRequest(command: "0 0", board: testBoard);
        }

        /// <summary>
        /// Test checking whether the successor is called
        /// </summary>
        [TestMethod]
        public void IsValidPlayCommandShouldCallItsSuccessorWhenNeeded()
        {
            var testHandler = new IsValidPlayCommandHandler();
            var testBoard = new Board(new EasyBoardSettings(), new List<IBoardObserver>());
            testHandler.SetSuccessor(new IsInsideBoardHandler());
            testBoard.Cells[0, 0] = new CellContext();
            testBoard.Cells[0, 0].Content = new EmptyContent();
            testBoard.Cells[0, 0].Content.Value = 1;
            testHandler.HandleRequest(command: "0 0", board: testBoard);
        }
    }
}