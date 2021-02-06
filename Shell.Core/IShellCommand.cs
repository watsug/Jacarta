// <copyright file="IShellCommand.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
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
