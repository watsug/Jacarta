// <copyright file="ITerminal.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// </copyright>
// <author>Adam Augustyn</author>

namespace Jacarta.Hal
{
    /// <summary>
    /// Abstracion of communication interface.
    /// </summary>
    public interface ITerminal
    {
        /// <summary>
        /// Exchanges the date with the terminal.
        /// </summary>
        /// <param name="data">Data to be sent.</param>
        /// <returns>Data returned from the terminal.</returns>
        byte[] Transmit(byte[] data);
    }
}
