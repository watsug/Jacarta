// <copyright file="ISecureMessaging.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace Jacarta.Smartcards.Iso7816
{
    /// <summary>
    /// Abstraction over secure channel.
    /// </summary>
    public interface ISecureMessaging
    {
        /// <summary>
        /// Protects C-APDU using session keys.
        /// </summary>
        /// <param name="capdu">Plain C-APDU.</param>
        /// <returns>Encrypted C-APDU.</returns>
        CommandApdu ProtectCommand(CommandApdu capdu);

        /// <summary>
        /// Unprotects C-APDU using session keys.
        /// </summary>
        /// <param name="capdu">Encrypted C-APDU.</param>
        /// <returns>Plain C-APDU.</returns>
        CommandApdu UnprotectCommand(CommandApdu capdu);

        /// <summary>
        /// Protects R-APDU using session keys.
        /// </summary>
        /// <param name="rapdu">Plain R-APDU.</param>
        /// <returns>Encrypted R-APDU.</returns>
        ResponseApdu ProtectResponse(ResponseApdu rapdu);

        /// <summary>
        /// Unprotects R-APDU using session keys.
        /// </summary>
        /// <param name="rapdu">Encrypted R-APDU.</param>
        /// <returns>Plain R-APDU.</returns>
        ResponseApdu UnprotectResponse(ResponseApdu rapdu);
    }
}
