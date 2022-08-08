namespace BrainFuckDotNet.Tests
{
    [TestFixture]
    internal class InterpreterTest
    {
        private Interpreter _sut;
        private TestConsole _testConsole;

        [SetUp]
        public void Setup()
        {
            _testConsole = new TestConsole();
            _sut = new Interpreter(_testConsole);
        }

        [Timeout(5000)]
        [TestCase("++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>.", "Hello World!\n")]
        [TestCase("-[------->+<]>-.-[->+++++<]>++.+++++++..+++.[--->+<]>-----.>-[--->+<]>-.-[----->+<]>.+[->+++<]>+.+++++++++++.++[->+++<]>+.+++++.", "Hello Twitch")]
        public void EnsureThat_InterpreterOutputs_Expected(string program, string expectedOutput)
        {
            _sut.Execute(program);
            Assert.That(_testConsole.ToString(), Is.EqualTo(expectedOutput));
        }

        [Test]
        [Timeout(5000)]
        public void EsureThat_Interpeter_HandlesCycles()
        {
            _sut.Execute(".+[.+]");
            Assert.That(_testConsole.WriteCount, Is.EqualTo(256));
        }
    }
}
