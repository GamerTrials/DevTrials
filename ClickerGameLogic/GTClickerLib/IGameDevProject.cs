using System;

namespace GTClicker
{
	public interface IGameDevProject
	{
		long FeaturesGenerated{ get;}

		IGameDevProject DevelopFeature();

		IGameDevProject TimeLapse (long deltaTime);

		IGameDevProject HarvestFeatures ();

		IGameDevProject Associate (IDeveloper m);

        long FeaturesGeneratedPerSec { get; }
	}
}

