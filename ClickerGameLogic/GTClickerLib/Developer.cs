﻿using System;

namespace GTClicker
{
	public class Developer: IDeveloper 
	{
		public double FeaturesGeneratedPerSec { get; private set; }

		public Developer ()
		{
			this.FeaturesGeneratedPerSec = 1;
		}
	}
}

