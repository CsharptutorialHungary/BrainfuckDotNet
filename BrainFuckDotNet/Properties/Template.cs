/*
 Generated by BrainFuckDotNet
 https://github.com/CsharptutorialHungary/BrainfuckDotNet
 */
using System;
using System.Runtime.CompilerServices;

using BrainFuckDotnet.Runtime;

namespace %NameSpaceName%
{
    public partial class %ClassName%
    {
        [CompilerGenerated]
        public void RunBrainFuck(IConsole console)
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
