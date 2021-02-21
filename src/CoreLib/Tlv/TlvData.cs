// <copyright file="TlvData.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace Jacarta.CoreLib.Tlv
{
    /// <summary>
    /// TLV data object.
    /// </summary>
    public class TlvData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TlvData"/> class.
        /// </summary>
        /// <param name="tag">Tag.</param>
        /// <param name="data">Data.</param>
        public TlvData(uint tag, byte[] data)
        {
            Tag = tag;
            Data = data;
        }

        /// <summary>
        /// Gets tag of data object.
        /// </summary>
        public uint Tag { get; private set; }

        /// <summary>
        /// Gets value of data object.
        /// </summary>
        public byte[] Data { get; private set; }
    }
}
