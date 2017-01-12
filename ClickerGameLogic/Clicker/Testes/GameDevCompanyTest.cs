using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GTClicker;
using Moq;

namespace Testes {

    [TestFixture()]
    class GameDevCompanyTest {

        private Mock<IGameStudio> GameStudioMock() {
            Mock < IGameStudio > ret = new Mock<IGameStudio>();
            ret.Setup((x) => x.Remove(It.IsAny<int>())).Returns(ret.Object);
            return ret;
        }
        
        private Mock<IMarketPlace> MarketPlaceMock() {
            Mock<IMarketPlace> ret = new Mock<IMarketPlace>();

			ret.Setup((x) => x.Sell(It.IsAny<ISellableGame>())).Returns(ret.Object);
            return ret;
        }


        [Test()]
        public void SellGameTest() {

            var market = MarketPlaceMock();
            var gameStudio = GameStudioMock();

            var gdcom = new GameDevCompany(market.Object, gameStudio.Object);

            gdcom.SellGame(0);

			market.Verify((x) => x.Sell(It.IsAny<ISellableGame>()), Times.Once());
            gameStudio.Verify((x) => x.Remove(0), Times.Once());
        }


    }
}
