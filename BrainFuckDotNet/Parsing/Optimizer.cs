using BrainFuckDotnet.Runtime;

using BrainFuckDotNet.Domain;

namespace BrainFuckDotNet.Parsing
{
    internal static class Optimizer
    {
        public static IList<IInstruction> Optimize(IList<IInstruction> raw)
        {
            if (raw.Count < 2)
                return raw;

            List<IInstruction> result = new();
            IInstruction current = raw[0];
            int sum = SetSumFromCurrent(current);
            string type = string.Empty;
            int processed = 0;
            for (int i = 1; i < raw.Count; i++)
            {
                if (AreSameType(current, raw[i]))
                {
                    if (raw[i] is Increment inc)
                    {
                        type = nameof(Increment);
                        sum += inc.Value;
                        processed++;
                    }
                    else if (raw[i] is PointerMove pm)
                    {
                        type = nameof(PointerMove);
                        sum += pm.Value;
                        processed++;
                    }
                    else
                    {
                        result.Add(OptimizeIfLoop(raw[i]));
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(type))
                    {
                        result.Add(OptimizeIfLoop(current));
                    }
                    else
                    {
                        result.Add(CreateInstruction(sum, type));
                    }
                    current = raw[i];
                    sum = SetSumFromCurrent(current);
                    processed = 0;
                    type = string.Empty;
                }
            }

            if (processed != 0)
            {
                result.Add(CreateInstruction(sum, type));
            }
            else
            {
                result.Add(OptimizeIfLoop(current));
            }

            return result;

        }

        private static IInstruction OptimizeIfLoop(IInstruction instruction)
        {
            if (instruction is Loop loop)
            {
                if (IsResetLoop(loop))
                    return new ResetCell();
            }
            return instruction;
        }

        private static bool IsResetLoop(Loop loop)
        {
            return loop.Instructions.Count == 1
                && loop.Instructions[0] is Increment;
        }

        private static IInstruction CreateInstruction(int sum, string type)
        {
            if (type == nameof(Increment))
                return new Increment { Value = sum };
            else if (type == nameof(PointerMove))
                return new PointerMove { Value = sum };
            else
                throw ExceptionFactory.Create(Error.ErrorOptimize);
        }

        private static int SetSumFromCurrent(IInstruction current)
        {
            return current is IValue value ? value.Value : 1;
        }

        private static bool AreSameType(IInstruction i1, IInstruction i2)
        {
            return i1.GetType() == i2.GetType();
        }
    }
}
