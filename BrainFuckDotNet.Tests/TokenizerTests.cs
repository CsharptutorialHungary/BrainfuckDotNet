namespace BrainFuckDotNet.Tests
{
    [TestFixture]
    internal class TokenizerTests
    {
        [Test]
        public void EnsureThat_Tokenizer_Parses_SimpleCorrect()
        {
            string program = "++--.,><";

            IList<IInstruction> expected = new List<IInstruction>
            {
                new Increment { Value = 1},
                new Increment { Value = 1},
                new Increment { Value = -1},
                new Increment { Value = -1},
                new Output(),
                new Input(),
                new PointerMove { Value = 1 },
                new PointerMove { Value = -1 },
            };

            IList<IInstruction> result = Tokenizer.Tokenize(program);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase("[[]")]
        [TestCase("[]]")]
        [TestCase("[[[]]")]
        [TestCase("[]]][[")]
        public void EnsureThat_Tokenizer_Throws_InvalidLoop(string invalidLoop)
        {
            Assert.Throws<BrainFuckException>(() =>
            {
                Tokenizer.Tokenize(invalidLoop);
            });
        }

        [Test]
        public void EnsureThat_Tokenizer_HandlesLoop()
        {
            string program = "[.+]";

            IList<IInstruction> expected = new List<IInstruction>
            {
                new Loop
                {
                    new Output(),
                    new Increment { Value = 1 },
                }
            };

            IList<IInstruction> result = Tokenizer.Tokenize(program);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void EnsureThat_Tokenizer_Handles_MultiLoop()
        {
            string program = "[[.+]].";

            IList<IInstruction> expected = new List<IInstruction>
            {
                new Loop
                {
                    new Loop
                    {
                        new Output(),
                        new Increment { Value = 1 },
                    }
                },
                new Output()
            };

            IList<IInstruction> result = Tokenizer.Tokenize(program);

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
