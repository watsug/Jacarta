// <copyright file="TlvObject.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace Jacarta.CoreLib.Tlv
{
    /// <summary>
    /// Base class for TLV objects.
    /// </summary>
    public abstract class TlvObject
    {
        /// <summary>
        /// Gets tag of data object.
        /// </summary>
        public abstract uint Tag { get; }

        /// <summary>
        /// Encodes the object int byte array.
        /// </summary>
        /// <param name="format">Encoding format.</param>
        /// <returns>Object encoded as byte array.</returns>
        public abstract byte[] Encode(Format format = Format.Auto);
    }
}
