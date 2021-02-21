// <copyright file="ParametrizedCommandBase.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace Jacarta.Shell.Base.Commands
{
    using Jacarta.Shell.Core;

    /// <summary>
    /// Base class for all parametrized commands.
    /// </summary>
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
