using System;

namespace GTClicker
{
	public interface IGameDevProject
	{
		long FeaturesGenerated{ get;}

		IGameDevProject DevelopFeature();

		IGameDevProject TimeLapse (long deltaTime);

		IGameDevProject Associate (IDeveloper m);

        long FeaturesGeneratedPerSec { get; }
	}
}

