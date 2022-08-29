namespace BrainFuckDotNet.Tests
{
    [TestFixture]
    public class OptimizerTests
    {
        [TestCase("+", 1)]
        [TestCase("-", -1)]
        [TestCase("--", -2)]
        [TestCase("++", 2)]
        [TestCase("+++++", 5)]
        [TestCase("+++++-----", 0)]
        public void EnsureThat_Optimizer_Optimizes_Increments_Correctly(string program, int expectedCount)
        {
            var tokens = Tokenizer.Tokenize(program);
            
            var results = Optimizer.Optimize(tokens);

            var expected = new IInstruction[]
            {
                new Increment { Value = expectedCount }
            };

            CollectionAssert.AreEqual(expected, results);
        }

        [TestCase(">", 1)]
        [TestCase("<", -1)]
        [TestCase("<<", -2)]
        [TestCase(">>", 2)]
        [TestCase(">>>>>", 5)]
        [TestCase(">>>>>><<<<<", 1)]
        public void EnsureThat_Optimizer_Optimizes_PointerMoves_Correctly(string program, int expectedCount)
        {
            var tokens = Tokenizer.Tokenize(program);

            var results = Optimizer.Optimize(tokens);

            var expected = new IInstruction[]
            {
                new PointerMove { Value = expectedCount }
            };

            CollectionAssert.AreEqual(expected, results);
        }

        [Test]
        public void EnsureThat_Optimizer_Optimizes_SimpleCorrect()
        {
            string program = "++.--.,>>.<<<<";

            IList<IInstruction> expected = new List<IInstruction>
            {
                new Increment { Value = 2},
                new Output(),
                new Increment { Value = -2},
                new Output(),
                new Input(),
                new PointerMove { Value = 2 },
                new Output(),
                new PointerMove { Value = -4 },
            };

            IList<IInstruction> result = Optimizer.Optimize(Tokenizer.Tokenize(program));

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void EnsureThat_Optimizer_Handles_NotOptimizableLoop()
        {
            string program = ".+[.+]";

            IList<IInstruction> expected = new List<IInstruction>
            {
                new Output(),
                new Increment { Value = 1 },
                new Loop
                {
                    new Output(),
                    new Increment { Value = 1 },
                }
            };

            IList<IInstruction> result = Optimizer.Optimize(Tokenizer.Tokenize(program));

            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase("[-]")]
        [TestCase("[+]")]
        public void EnsureThat_Optimizer_Handles_Optimizable_Loop(string subprogram)
        {
            string program = ".+" + subprogram;

            IList<IInstruction> expected = new List<IInstruction>
            {
                new Output(),
                new Increment { Value = 1 },
                new ResetCell(),
            };

            IList<IInstruction> result = Optimizer.Optimize(Tokenizer.Tokenize(program));

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
