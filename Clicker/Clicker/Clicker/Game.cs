using System;
using System.Collections.Generic;

namespace GTClicker
{
	public class Game: IGame
	{
		IList<IMonkey> monkeys = new List<IMonkey> ();
		
		public long TrialPiecesGenerated {
			get {
				return (long)fractionalTrialPiecesGenerated;
			}
		}

        public long TrialPiecesPerSec {
            get { return monkeys.Count; }
        }

        private double fractionalTrialPiecesGenerated;
			


		private Game (double generated, IList<IMonkey> monkeys) {
			fractionalTrialPiecesGenerated = generated;
			this.monkeys = monkeys;
		}

		public Game ()
		{
		}

		public IGame MakeReport () {
			return new Game (this.fractionalTrialPiecesGenerated + 1, this.monkeys);
		}

		public IGame HarvestTrialPieces () {
			return new Game (0, this.monkeys);
		}

		public IGame TimeLapse(long milliseconds){
			double generated = this.fractionalTrialPiecesGenerated + ((milliseconds/1000.0)*this.monkeys.Count); 

			return new Game (generated, this.monkeys);
		}

		public IGame Associate(IMonkey monkey){
  
			var copy = new List<IMonkey> (this.monkeys);
			copy.Add (monkey);
			return new Game (this.fractionalTrialPiecesGenerated, copy);
		}
	}
}

