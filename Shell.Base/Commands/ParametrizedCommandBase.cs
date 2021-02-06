﻿namespace Jacarta.Shell.Base.Commands
{
    using Jacarta.Shell.Core;

    public class ParametrizedCommandBase : IShellCommand
    {
        public void Execute(string parameters)
        {
            throw new System.NotImplementedException(nameof(Execute));
        }

        public void Help()
        {
            throw new System.NotImplementedException(nameof(Help));
        }
    }
}
