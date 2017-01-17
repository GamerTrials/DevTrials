using System;

namespace GTClicker
{
	public class SeniorDeveloper: IDeveloper 
	{
		public double FeaturesGeneratedPerSec { get; private set; }
		public SeniorDeveloper ()
		{
			this.FeaturesGeneratedPerSec = 5;
		}
	}
}

