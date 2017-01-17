using System;

namespace GTClicker
{
	public class JuniorDeveloper: IDeveloper 
	{
		public double FeaturesGeneratedPerSec { get; private set; }
		public JuniorDeveloper ()
		{
			this.FeaturesGeneratedPerSec = 0.5;
		}
	}
}

