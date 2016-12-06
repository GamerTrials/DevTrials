using NUnit.Framework;
using System;
using Moq;
using GTClicker;

namespace Testes
{

	[TestFixture ()]
	public class CLITest
	{
        public Mock<IGame> GenerateMock() {
            var mock = new Mock<IGame>();
            var mockObj = mock.Object;
            mock.Setup((x) => x.Associate(It.IsAny<IMonkey>())).Returns(mock.Object);
            mock.Setup((x) => x.MakeReport()).Returns( mock.Object);
            mock.Setup((x) => x.TimeLapse(It.IsAny<long>())).Returns( mock.Object);
            mock.Setup((x) => x.HarvestTrialPieces()).Returns(mock.Object);
            return mock;
        }

		[Test ()]
		public void Click ()
		{
            var mock = this.GenerateMock();
			mock.SetupGet ((x) => x.TrialPiecesGenerated).Returns(1);
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
			mock.Verify ((x) => x.MakeReport (), Times.Once);
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
            mock.Verify((x) => x.Associate(It.IsAny<IMonkey>()), Times.Once);
        }

        [Test]
        public void AddMonkeyCalledAfterTimeLapse() {
            var mock = this.GenerateMock();
            var cli = new CLI(mock.Object);
            int callOrder = 0;
            mock.Setup(x => x.Associate(It.IsAny<IMonkey>()))
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
            mock.Setup((x) => x.HarvestTrialPieces()).Returns(mock.Object);
            cli.Input("m\n", 200L);
            mock.Verify((x) => x.HarvestTrialPieces(), Times.Once);
        }

    }
}

