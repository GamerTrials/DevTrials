using NUnit.Framework;
using System;
using GTClicker;

namespace Testes
{
	[TestFixture ()]
	public class GameTest
	{
		[Test ()]
		public void NoChangeAfterTime ()
		{
			var oven = new Game ();
			var time = 1000L;
			var newoven = oven.TimeLapse (time);
			Assert.AreEqual (0, newoven.TrialPiecesGenerated);
		}

		[Test ()]
		public void OvenCLicked ()
		{
			var oven = new Game ();
			var newOven = oven.MakeReport ();
			Assert.AreEqual (1, newOven.TrialPiecesGenerated);
		}

		[Test ()]
		public void OvenHarvested ()
		{
			var oven = new Game ();
			var newOven = oven.MakeReport ();
			newOven = newOven.HarvestTrialPieces ();
			Assert.AreEqual (0, newOven.TrialPiecesGenerated);
		}

		[Test ()]
		public void OvenClickedTwice ()
		{
			var oven = new Game ();
			var newOven = oven.MakeReport ().MakeReport ();
			Assert.AreEqual (2, newOven.TrialPiecesGenerated);
		}

		[Test ()]
		public void MonkeyGeneratedOneTrialPiece ()
		{
			var monkey = new Monkey ();
			IGame game = new Game ();
			game = game.Associate (monkey);
			game = game.TimeLapse (1000L);

			Assert.AreEqual (1, game.TrialPiecesGenerated);
		}

		[Test ()]
		public void MonkeyGeneratedTwoTrialPiece ()
		{
			var monkey = new Monkey ();
			IGame game = new Game ();
			game = game.Associate (monkey);
			game = game.TimeLapse (2000L);

			Assert.AreEqual (2, game.TrialPiecesGenerated);
		}

		[Test ()]
		public void MonkeyGeneratedOneTrialPieceInTwoDistinctTimeLapses ()
		{
			var monkey = new Monkey ();
			IGame game = new Game ();
			game = game.Associate (monkey);
			game = game.TimeLapse (500L);
			game = game.TimeLapse (500L);

			Assert.AreEqual (1, game.TrialPiecesGenerated);
		}

		[Test ()]
		public void MonkeyGeneratedZeroNoTimeLapse ()
		{
			var monkey = new Monkey ();
			IGame game = new Game ();
			game = game.Associate (monkey);

			Assert.AreEqual (0, game.TrialPiecesGenerated);
		}

        /*,[Test()]
        public void WorkerGeneratedOwnValue() {
            var monkey = new Monkey();
            IGame game = new Game();
            game = game.Associate(monkey);
            game = game.TimeLapse(1000L);

            Assert.AreEqual(monkey.BPS(), game.TrialPiecesGenerated);
        }*/



    }
}

