using NUnit.Framework;
using System;
using GTClicker;

namespace Testes
{
	[TestFixture ()]
	public class GameDevProjectTest
	{
		[Test ()]
		public void NoChangeAfterTime ()
		{
			var project = new GameDevProject ();
			var time = 1000L;
			var newproject = project.TimeLapse (time);
			Assert.AreEqual (0, newproject.FeaturesGenerated);
		}

		[Test ()]
		public void projectCLicked ()
		{
			var project = new GameDevProject ();
			var newproject = project.DevelopFeature ();
			Assert.AreEqual (1, newproject.FeaturesGenerated);
		}

		[Test ()]
		public void projectClickedTwice ()
		{
			var project = new GameDevProject ();
			var newproject = project.DevelopFeature ().DevelopFeature ();
			Assert.AreEqual (2, newproject.FeaturesGenerated);
		}

		[Test ()]
		public void DevGeneratedOneFeature ()
		{
			var dev = new Developer ();
			IGameDevProject game = new GameDevProject ();
			game = game.Associate (dev);
			game = game.TimeLapse (1000L);

			Assert.AreEqual (1, game.FeaturesGenerated);
		}

		[Test ()]
		public void DevGeneratedTwoFeature ()
		{
			var dev = new Developer ();
			IGameDevProject game = new GameDevProject ();
			game = game.Associate (dev);
			game = game.TimeLapse (2000L);

			Assert.AreEqual (2, game.FeaturesGenerated);
		}

		[Test ()]
		public void DevGeneratedOneFeatureInTwoDistinctTimeLapses ()
		{
			var dev = new Developer ();
			IGameDevProject game = new GameDevProject ();
			game = game.Associate (dev);
			game = game.TimeLapse (500L);
			game = game.TimeLapse (500L);

			Assert.AreEqual (1, game.FeaturesGenerated);
		}

		[Test ()]
		public void DevGeneratedZeroNoTimeLapse ()
		{
			var dev = new Developer ();
			IGameDevProject game = new GameDevProject ();
			game = game.Associate (dev);

			Assert.AreEqual (0, game.FeaturesGenerated);
		}

    }
}

