using System;
using GTClicker;
using NUnit.Framework;

namespace Testes    
{
    [TestFixture()]
    class CLIFunctionalTests
    {
        [Test()]
        public void AddMonkeyGenerate() {
            var cli = new CLI(new Game());
            cli.Input("m\n", 0L);
            string output = cli.Input("\n", 1000L);
            Assert.AreEqual("Trial Pieces: 2\nTrial Pieces por segundo: 1", output);
        }
    }
}
