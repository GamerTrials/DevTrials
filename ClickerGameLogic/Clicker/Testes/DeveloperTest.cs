using System;
using GTClicker;
using NUnit.Framework;

namespace Testes    
{
	[TestFixture()]
	class DeveloperTest
	{
		[Test()]
		public void TestJuniorDeveloperGeneratesHalfAFeaturePerSec() {
			var juniorDev = new JuniorDeveloper ();
			Assert.AreEqual (0.5, juniorDev.FeaturesGeneratedPerSec);
		}

		[Test()]
		public void TestSeniorDeveloperGenerates5FeaturePerSec() {
			var seniorDev = new SeniorDeveloper ();
			Assert.AreEqual (5, seniorDev.FeaturesGeneratedPerSec);
		}

		[Test()]
		public void TestDeveloperGenerates1FeaturePerSec() {
			var dev = new Developer ();
			Assert.AreEqual (1, dev.FeaturesGeneratedPerSec);
		}
	}
}
