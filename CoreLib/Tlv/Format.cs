// <copyright file="Format.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
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
    }
}
