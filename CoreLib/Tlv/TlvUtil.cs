// <copyright file="TlvUtil.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// </copyright>
// <author>Adam Augustyn</author>

namespace Jacarta.CoreLib.Tlv
{
    using System;
    using System.IO;

    /// <summary>
    /// TLV utility class providing methods to simplify TLV data processing.
    /// </summary>
    public static class TlvUtil
    {
        /// <summary>
        /// Encode length field according to given format.
        /// </summary>
        /// <param name="s">Output stream.</param>
        /// <param name="length">Length to be encoded.</param>
        /// <param name="format">Encoding format.</param>
        public static void EncodeLength(Stream s, ulong length, Format format = Format.BerIso)
        {
        }

        /// <summary>
        /// Gets length of length field.
        /// </summary>
        /// <param name="buff">Input buffer.</param>
        /// <param name="offset">Offset to start.</param>
        /// <returns>Length of length field.</returns>
        public static int GetLengthFieldLen(Span<byte> buff, int offset)
        {
            throw new NotImplementedException(nameof(GetLengthFieldLen));
        }

        /// <summary>
        /// Decode length.
        /// </summary>
        /// <param name="buff">Input buffer.</param>
        /// <param name="offset">Offset to start.</param>
        /// <param name="format">Encoding format (default Auto).</param>
        /// <returns>Decoded length.</returns>
        public static uint GetLength(Span<byte> buff, int offset, Format format = Format.Auto)
        {
            throw new NotImplementedException(nameof(GetLength));
        }

        /// <summary>
        /// Gets length of TAG field.
        /// </summary>
        /// <param name="buff">Input buffer.</param>
        /// <param name="offset">Offset to start.</param>
        /// <returns>Length of length field.</returns>
        public static int GetTagLen(Span<byte> buff, int offset)
        {
            throw new NotImplementedException(nameof(GetTagLen));
        }

        /// <summary>
        /// Decode TAG.
        /// </summary>
        /// <param name="buff">Input buffer.</param>
        /// <param name="offset">Offset to start.</param>
        /// <param name="format">Encoding format (default Auto).</param>
        /// <returns>Decoded TAG.</returns>
        public static uint GetTag(Span<byte> buff, int offset, Format format = Format.Auto)
        {
            throw new NotImplementedException(nameof(GetTag));
        }

    }
}
