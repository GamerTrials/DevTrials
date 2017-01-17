using System;
using System.Collections.Generic;

namespace GTClicker
{
	public class GameDevProject: IGameDevProject
	{
		IList<IDeveloper> devs = new List<IDeveloper> ();
		
		public long FeaturesGenerated {
			get {
				return (long)fractionalFeaturesGenerated;
			}
		}

        public long FeaturesGeneratedPerSec {
            get { return devs.Count; }
        }

        private double fractionalFeaturesGenerated;
			


		private GameDevProject (double generated, IList<IDeveloper> devs) {
			fractionalFeaturesGenerated = generated;
			this.devs = devs;
		}

		public GameDevProject ()
		{
		}

		public IGameDevProject DevelopFeature () {
			return new GameDevProject (this.fractionalFeaturesGenerated + 1, this.devs);
		}

		public IGameDevProject TimeLapse(long milliseconds) {
			double seconds = (double)milliseconds / 1000.0;
			double generated = this.fractionalFeaturesGenerated;

			foreach(var developer in this.devs) {
				generated = generated + developer.FeaturesGeneratedPerSec * seconds;
			}

			return new GameDevProject (generated, this.devs);
		}

		public IGameDevProject Associate(IDeveloper dev) {
			var copy = new List<IDeveloper> (this.devs);
			copy.Add (dev);
			return new GameDevProject (this.fractionalFeaturesGenerated, copy);
		}
	}
}

