// <copyright file="TlvData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
