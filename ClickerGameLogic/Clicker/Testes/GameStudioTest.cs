using NUnit.Framework;
using System;
using GTClicker;
using Moq;

namespace Testes {

    [TestFixture()]
    class GameStudioTest {

        public Mock<IGameDevProject> GenerateMock() {
            var mock = new Mock<IGameDevProject>();
            var mockObj = mock.Object;
            mock.Setup((x) => x.Associate(It.IsAny<IDeveloper>())).Returns(mock.Object);
            mock.Setup((x) => x.DevelopFeature()).Returns(mock.Object);
            mock.Setup((x) => x.TimeLapse(It.IsAny<long>())).Returns(mock.Object);
            mock.Setup((x) => x.HarvestFeatures()).Returns(mock.Object);
            return mock;
        }

        [Test()]
        public void AddDevTest() {
            var gameDevProjectMock = this.GenerateMock(); 
            var gameStudio = new GameStudio(()=> gameDevProjectMock.Object);
            gameStudio = gameStudio.AddDev(0);
            gameDevProjectMock.Verify(
                (x) => x.Associate(It.IsAny<IDeveloper>()),
                Times.Once);
        }

        [Test()]
        public void NotAddDevTest() {
            var gameDevProjectMock = this.GenerateMock();
            var gameStudio = new GameStudio(() => gameDevProjectMock.Object);
            gameDevProjectMock.Verify(
                (x) => x.Associate(It.IsAny<IDeveloper>()),
                Times.Never);
        }

        //[Test()]
        //public void CannotBuyDevTest() {
        //    var gameDevProjectMock = this.GenerateMock();
        //    var gameStudio = new GameStudio(() => gameDevProjectMock.Object,0); //(ProjectFactory, Currency)
        //    gameStudio = gameStudio.AddDev(0);
        //    gameDevProjectMock.Verify(
        //        (x) => x.Associate(It.IsAny<IDeveloper>()),
        //        Times.Never);
        //}
    }
}
