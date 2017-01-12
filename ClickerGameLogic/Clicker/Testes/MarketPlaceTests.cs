using NUnit.Framework;
using System;
using GTClicker;
using Moq;


namespace Testes
{
	[TestFixture()]
	public class MarketPlaceTests
	{
		public MarketPlaceTests ()
		{
			}
		[Test]
		public void VerifyGameSizeTest(){
			IMarketPlace marketPlace = new MarketPlace ();
			Mock<ISellableGame> s = new Mock<ISellableGame> ();

			marketPlace = marketPlace.Sell(s.Object);
			s.VerifyGet((x)=> x.GameSize, Times.AtLeastOnce);
		}

		[Test]
		public void SellGamesGiveMeMoney10(){
			IMarketPlace marketPlace = new MarketPlace ();
			Mock<ISellableGame> s = new Mock<ISellableGame> ();

			s.SetupGet ((x) => x.GameSize).Returns(10);

			marketPlace = marketPlace.Sell(s.Object);
			Assert.AreEqual (10, marketPlace.TotalMoney);
		}

		[Test]
		public void SellGamesGiveMeMoney20(){
			IMarketPlace marketPlace = new MarketPlace ();
			Mock<ISellableGame> s = new Mock<ISellableGame> ();

			s.SetupGet ((x) => x.GameSize).Returns(20);

			marketPlace = marketPlace.Sell(s.Object);
			Assert.AreEqual (20, marketPlace.TotalMoney);
		}

		[Test]
		public void SellGamesGiveMeMoney10And20(){
			IMarketPlace marketPlace = new MarketPlace ();
			Mock<ISellableGame> s = new Mock<ISellableGame> ();

			s.SetupGet ((x) => x.GameSize).Returns(20);

			marketPlace = marketPlace.Sell(s.Object);
			marketPlace = marketPlace.Sell(s.Object);
			Assert.AreEqual (40, marketPlace.TotalMoney);
		}
	}

}

