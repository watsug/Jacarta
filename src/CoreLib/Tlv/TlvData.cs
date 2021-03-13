// <copyright file="TlvData.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace Jacarta.CoreLib.Tlv
{
    using System;

    /// <summary>
    /// TLV data object.
    /// </summary>
    public class TlvData : TlvObject
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
        public override uint Tag { get; }

        /// <summary>
        /// Gets value of data object.
        /// </summary>
        public byte[] Data { get; private set; }

        /// <summary>
        /// Encodes the object int byte array.
        /// </summary>
        /// <param name="format">Encoding format.</param>
        /// <returns>Object encoded as byte array.</returns>
        public override byte[] Encode(Format format = Format.Auto)
        {
            // TODO: predict TAG length
            var lenLength = TlvUtil.PredictLengthLength((ulong)Data.Length, format);
            var buff = new byte[1 + lenLength + Data.Length];
            buff[0] = (byte)Tag;
            TlvUtil.EncodeLength(buff, 1, (ulong)Data.Length, format);
            Array.Copy(Data, 0, buff, lenLength + 1, Data.Length);
            return buff;
        }
    }
}
