// <copyright file="IApduTerminal.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace Jacarta.Smartcards.Iso7816
{
    /// <summary>
    /// Abstracion of APDU terminal.
    /// </summary>
    public interface IApduTerminal
    {
        /// <summary>
        /// Performs C-APDU / R-APDU uexchange.
        /// </summary>
        /// <param name="capdu">C-APDU to be sent.</param>
        /// <returns>R-APDU received.</returns>
        ResponseApdu Transmit(CommandApdu capdu);
    }
}
