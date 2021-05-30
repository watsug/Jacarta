// <copyright file="LvData.cs" company="augustyn.net">
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
    public class LvData : IEncodableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LvData"/> class.
        /// </summary>
        /// <param name="tag">Tag.</param>
        /// <param name="data">Data.</param>
        public LvData(byte[] data)
        {
            Data = data;
        }

        /// <summary>
        /// Gets value of data object.
        /// </summary>
        public byte[] Data { get; private set; }

        /// <summary>
        /// Encodes the object int byte array.
        /// </summary>
        /// <param name="format">Encoding format.</param>
        /// <returns>Object encoded as byte array.</returns>
        public byte[] Encode(Format format = Format.Auto)
        {
            var lenLength = TlvUtil.PredictLengthLength((ulong)Data.Length, format);

            var buff = new byte[lenLength + Data.Length];

            TlvUtil.EncodeLength(buff, 0, (ulong)Data.Length, format);
            Data.AsSpan().CopyTo(buff.AsSpan(lenLength));

            return buff;
        }
    }
}
