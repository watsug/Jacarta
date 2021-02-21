// <copyright file="IShellCommand.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace Jacarta.Shell.Core
{
    public interface IShellCommand
    {
        void Execute(string parameters);

        void Help();
    }
}
