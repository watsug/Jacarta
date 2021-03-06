﻿// <copyright file="CommandApdu.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace Jacarta.Smartcards.Iso7816
{
    using System;

    /// <summary>
    /// ISO 7816 command APDU.
    /// </summary>
    public class CommandApdu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandApdu"/> class.
        /// </summary>
        /// <param name="cla">Class byte.</param>
        /// <param name="cmd">Command byte.</param>
        /// <param name="p1">P1 parameter byte.</param>
        /// <param name="p2">P2 parameter byte.</param>
        /// <param name="data">Data field.</param>
        /// <param name="le">Expected length.</param>
        public CommandApdu(int cla, int cmd, int p1, int p2, byte[] data, int? le)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandApdu"/> class.
        /// </summary>
        /// <param name="cla">Class byte.</param>
        /// <param name="cmd">Command byte.</param>
        /// <param name="p1">P1 parameter byte.</param>
        /// <param name="p2">P2 parameter byte.</param>
        /// <param name="data">Data field.</param>
        public CommandApdu(int cla, int cmd, int p1, int p2, byte[] data)
            : this(cla, cmd, p1, p2, data, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandApdu"/> class.
        /// </summary>
        /// <param name="cla">Class byte.</param>
        /// <param name="cmd">Command byte.</param>
        /// <param name="p1">P1 parameter byte.</param>
        /// <param name="p2">P2 parameter byte.</param>
        public CommandApdu(int cla, int cmd, int p1, int p2)
            : this(cla, cmd, p1, p2, Array.Empty<byte>())
        {
        }

        /// <summary>
        /// Gets a value indicating whether APDU is extended-length.
        /// </summary>
        public virtual bool ExtendedLength => false;
    }
}
