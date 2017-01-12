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
            return mock;
        }

        [Test()]
        public void AddDevToProjectTest() {
            var gameDevProjectMock = this.GenerateMock(); 
			IGameStudio gameStudio = new GameStudio(()=> gameDevProjectMock.Object,1);
			gameStudio = gameStudio.AddDevToFreePool ();
			gameStudio = gameStudio.AddDevtoProject(0);
            gameDevProjectMock.Verify(
                (x) => x.Associate(It.IsAny<IDeveloper>()),
                Times.Once);
        }

		[Test()]
		public void CantAddDevsIfNoFreeDevs() {
			var gameDevProjectMock = this.GenerateMock(); 
			IGameStudio gameStudio = new GameStudio(()=> gameDevProjectMock.Object);
			gameStudio = gameStudio.AddDevtoProject(0);
			gameDevProjectMock.Verify(
				(x) => x.Associate(It.IsAny<IDeveloper>()),
				Times.Never);
		}

        [Test()]
        public void NotAddDevTest() {
            var gameDevProjectMock = this.GenerateMock();
            var gameStudio = new GameStudio(() => gameDevProjectMock.Object);
            gameDevProjectMock.Verify(
                (x) => x.Associate(It.IsAny<IDeveloper>()),
                Times.Never);
        }

        [Test()]
        public void CanAddFreeDevs() {
            var gameDevProjectMock = this.GenerateMock();
			IGameStudio gameStudio = new GameStudio(() => gameDevProjectMock.Object,0); //(ProjectFactory, Currency)
            gameStudio = gameStudio.AddDevToFreePool();
            gameDevProjectMock.Verify(
                (x) => x.Associate(It.IsAny<IDeveloper>()),
                Times.Never);

			Assert.AreEqual (1, gameStudio.FreeDevPool);
        }

		[Test()]
		public void RemoveGameFreeMyDevs42(){
			var gameDevProjectMock = this.GenerateMock();
			gameDevProjectMock.SetupGet ((x) => x.FeaturesGeneratedPerSec).Returns (42);

			IGameStudio gameStudio = new GameStudio(() => gameDevProjectMock.Object,0); //(ProjectFactory, Currency)
			gameStudio = gameStudio.Remove(0);
			Assert.AreEqual (42, gameStudio.FreeDevPool);
			
		}

		[Test()]
		public void RemoveGameFreeMyDevs2(){
			var gameDevProjectMock = this.GenerateMock();
			gameDevProjectMock.SetupGet ((x) => x.FeaturesGeneratedPerSec).Returns (2);

			IGameStudio gameStudio = new GameStudio(() => gameDevProjectMock.Object,0); //(ProjectFactory, Currency)
			gameStudio = gameStudio.Remove(0);
			Assert.AreEqual (2, gameStudio.FreeDevPool);

		}

		[Test()]
		public void NewStudiosDontHaveFreeDevs(){
			var gameDevProjectMock = this.GenerateMock();
			IGameStudio gameStudio = new GameStudio(() => gameDevProjectMock.Object,0); //(ProjectFactory, Currency)
			Assert.AreEqual (0, gameStudio.FreeDevPool);

		}
    }
}
