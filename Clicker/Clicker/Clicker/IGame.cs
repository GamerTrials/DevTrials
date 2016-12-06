using System;

namespace GTClicker
{
	public interface IGame
	{
		long TrialPiecesGenerated{ get;}

		IGame MakeReport();

		IGame TimeLapse (long deltaTime);

		IGame HarvestTrialPieces ();

		IGame Associate (IMonkey m);

        long TrialPiecesPerSec { get; }
	}
}

