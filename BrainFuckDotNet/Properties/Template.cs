using System;
using System.Runtime.CompilerServices;

using BrainFuckDotnet.Runtime;

namespace %NameSpaceName%
{
    public partial class %ClassName%
    {
        [CompilerGenerated]
        public void RunBrainFuck()
        {
            try
            {
                byte[] mem = new byte[30_000];
                int i = 0;
                %Generated%
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.Create(Error.ErrorRuntimeError, ex, ex.Message);
            }
        }
    }
}
