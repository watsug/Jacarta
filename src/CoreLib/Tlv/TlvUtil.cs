// <copyright file="TlvUtil.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
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
        /// The most significant bit is set.
        /// </summary>
        public const byte Msb = 0x80;

        /// <summary>
        /// Length field mask for TLV lenght field.
        /// </summary>
        public const byte LengthMask = 0x7F;

        /// <summary>
        /// Mask used to signalize, that TAG is encoded on more than one byte.
        /// </summary>
        public const byte ExtendedTagMask = 0x1f;

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
            var b1 = buff[offset];
            if ((Msb & b1) == 0)
            {
                return b1;
            }

            b1 &= LengthMask;

            if (b1 > sizeof(uint))
            {
                throw new ArgumentOutOfRangeException($"TLV length encoded on more than 4 bytes is not supported yet ({b1})!");
            }

            uint ret = 0;
            for (int i = 1; i <= b1; i++)
            {
                ret <<= 8;
                ret |= buff[offset + i];
            }

            // TODO: validate according to format
            return ret;
        }

        /// <summary>
        /// Gets length of TAG field.
        /// </summary>
        /// <param name="buff">Input buffer.</param>
        /// <param name="offset">Offset to start.</param>
        /// <returns>Length of length field.</returns>
        public static int GetTagLen(Span<byte> buff, int offset)
        {
            var b1 = buff[offset];
            if ((b1 & ExtendedTagMask) != ExtendedTagMask)
            {
                return 1;
            }

            int length = 1;
            for (int i = 1; i < buff.Length - offset; i++)
            {
                var bn = buff[offset + i];
                length++;
                if ((bn & Msb) == 0)
                {
                    break;
                }
            }

            return length;
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
