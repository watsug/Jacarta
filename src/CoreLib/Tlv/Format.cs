// <copyright file="Format.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace Jacarta.CoreLib.Tlv
{
    /// <summary>
    /// Type of TLV encoding.
    /// </summary>
    public enum Format
    {
        /// <summary>
        /// Auto - used mainly for decoding.
        /// </summary>
        Auto,

        /// <summary>
        /// Simple TLV
        /// </summary>
        Tlv,

        /// <summary>
        /// DER (Distingished Encoding Rules)
        /// </summary>
        Der,

        /// <summary>
        /// BER (Basic Encoding Rules)
        /// </summary>
        Ber,

        /// <summary>
        /// BER according to ISO 7816-4 (Basic Encoding Rules)
        /// </summary>
        BerIso,

        /// <summary>
        /// Length encoded always on 1 byte
        /// </summary>
        OneByteLength,

        /// <summary>
        /// Length encoded always on 2 bytes
        /// </summary>
        TwoBytesLength,
    }
}
