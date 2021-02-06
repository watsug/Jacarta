// <copyright file="IShellCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
