using NUnit.Framework;
using System;
using Moq;
using GTClicker;

namespace Testes
{

	[TestFixture ()]
	public class CLITest
	{
        public Mock<IGameDevProject> GenerateMock() {
            var mock = new Mock<IGameDevProject>();
            var mockObj = mock.Object;
            mock.Setup((x) => x.Associate(It.IsAny<IDeveloper>())).Returns(mock.Object);
            mock.Setup((x) => x.DevelopFeature()).Returns( mock.Object);
            mock.Setup((x) => x.TimeLapse(It.IsAny<long>())).Returns( mock.Object);
            mock.Setup((x) => x.HarvestFeatures()).Returns(mock.Object);
            return mock;
        }

		[Test ()]
		public void Click ()
		{
            var mock = this.GenerateMock();
			mock.SetupGet ((x) => x.FeaturesGenerated).Returns(1);
			var cli = new CLI(mock.Object);
			string output = cli.Input("\n", 0L);
			Assert.AreEqual ("Trial Pieces: 1\nTrial Pieces por segundo: 0", output);
		}

		[Test ()]
		public void ClickOnceOnEnter ()
		{
			var mock = this.GenerateMock();
            var cli = new CLI(mock.Object);
			cli.Input("\n", 0L);
			mock.Verify ((x) => x.DevelopFeature (), Times.Once);
		}

        [Test()]
        public void TimeLapse() {
            var mock = this.GenerateMock();
            var cli = new CLI(mock.Object);
            cli.Input("\n", 200L);
            mock.Verify((x) => x.TimeLapse(200L), Times.Once);
        }

        [Test()]
        public void AddMonkey() {
            var mock = this.GenerateMock();
            var cli = new CLI(mock.Object);
            cli.Input("m\n", 200L);
            mock.Verify((x) => x.Associate(It.IsAny<IDeveloper>()), Times.Once);
        }

        [Test]
        public void AddMonkeyCalledAfterTimeLapse() {
            var mock = this.GenerateMock();
            var cli = new CLI(mock.Object);
            int callOrder = 0;
            mock.Setup(x => x.Associate(It.IsAny<IDeveloper>()))
                .Callback(() => Assert.That(callOrder++, Is.EqualTo(1))).Returns(mock.Object);
            mock.Setup(x => x.TimeLapse(It.IsAny<long>()))
                .Callback(() => Assert.That(callOrder++, Is.EqualTo(0)))
                .Returns(mock.Object);
            cli.Input("m\n", 200L);
        }

        [Test]
        public void HarvestOnInput() {
            var mock = this.GenerateMock();
            var cli = new CLI(mock.Object);
            mock.Setup((x) => x.HarvestFeatures()).Returns(mock.Object);
            cli.Input("m\n", 200L);
            mock.Verify((x) => x.HarvestFeatures(), Times.Once);
        }

    }
}

