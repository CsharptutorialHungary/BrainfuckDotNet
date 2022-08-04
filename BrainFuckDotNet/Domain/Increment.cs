using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFuckDotNet.Domain
{
    /// <summary>
    /// +, -
    /// </summary>
    internal record struct Increment : IInstruction
    {
        public int Value { get; set; }
    }
}
