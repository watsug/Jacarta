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
        /// Mask used to valida if length can be encoded on one byte.
        /// </summary>
        public const uint OneByteLengthMask = 0xFFFFFF00;

        /// <summary>
        /// Mask used to valida if length can be encoded on two bytes.
        /// </summary>
        public const uint TwoBytesLengthMask = 0xFFFF0000;

        /// <summary>
        /// Mask used to valida if length can be encoded on three bytes.
        /// </summary>
        public const uint ThreeBytesLengthMask = 0xFF000000;

        /// <summary>
        /// Returns length field length according to given format.
        /// </summary>
        /// <param name="length">Length to be encoded.</param>
        /// <param name="format">Encoding format.</param>
        /// <returns>Predicted size of length field.</returns>
        public static int PredictLengthLength(ulong length, Format format = Format.Der)
        {
            if (format == Format.OneByteLength)
            {
                if ((length & OneByteLengthMask) != 0)
                {
                    throw new ArgumentOutOfRangeException($"This length cannot be encoded on one byte: {length:X}h");
                }

                return 1;
            }

            if (format == Format.TwoBytesLength)
            {
                if ((length & TwoBytesLengthMask) != 0)
                {
                    throw new ArgumentOutOfRangeException($"This length cannot be encoded on one byte: {length:X}h");
                }

                return 2;
            }

            return length < 0x80
                ? 1
                : length <= 0xff
                    ? 2
                    : length <= 0xffff
                        ? 3
                        : length <= 0xffffff ? 4 : 5;
        }

        /// <summary>
        /// Encode length field according to given format.
        /// </summary>
        /// <param name="stream">Output stream.</param>
        /// <param name="length">Length to be encoded.</param>
        /// <param name="format">Encoding format.</param>
        public static void EncodeLength(Stream stream, ulong length, Format format = Format.Der)
        {
            var buffLen = PredictLengthLength(length, format);
            Span<byte> buff = stackalloc byte[buffLen];

            if (format == Format.OneByteLength || length < 0x80)
            {
                buff[0] = (byte)length;
            }
            else if (format == Format.TwoBytesLength)
            {
                buff[0] = (byte)(length >> 8);
                buff[1] = (byte)(length & 0xff);
            }
            else if ((length & OneByteLengthMask) == 0)
            {
                // length < 0x80 is already addressed in the first condition
                buff[0] = Msb | 0x01;
                buff[1] = (byte)(length & 0xff);
            }
            else if ((length & TwoBytesLengthMask) == 0)
            {
                buff[0] = Msb | 0x02;
                buff[1] = (byte)(length >> 8);
                buff[2] = (byte)(length & 0xff);
            }
            else if ((length & ThreeBytesLengthMask) == 0)
            {
                buff[0] = Msb | 0x03;
                buff[1] = (byte)(length >> 16);
                buff[2] = (byte)((length >> 8) & 0xff);
                buff[3] = (byte)(length & 0xff);
            }
            else
            {
                buff[0] = Msb | 0x04;
                buff[1] = (byte)(length >> 24);
                buff[2] = (byte)((length >> 16) & 0xff);
                buff[3] = (byte)((length >> 8) & 0xff);
                buff[4] = (byte)(length & 0xff);
            }

            stream.Write(buff);
        }

        /// <summary>
        /// Gets length of length field.
        /// </summary>
        /// <param name="buff">Input buffer.</param>
        /// <param name="offset">Offset to start.</param>
        /// <returns>Length of length field.</returns>
        public static int GetLengthFieldLen(ReadOnlySpan<byte> buff, int offset)
        {
            var b1 = buff[offset];
            return ((Msb & b1) == 0) ? sizeof(byte) : sizeof(byte) + b1 & LengthMask;
        }

        /// <summary>
        /// Decode length.
        /// </summary>
        /// <param name="buff">Input buffer.</param>
        /// <param name="offset">Offset to start.</param>
        /// <param name="format">Encoding format (default Auto).</param>
        /// <returns>Decoded length.</returns>
        public static uint GetLength(ReadOnlySpan<byte> buff, int offset, Format format = Format.Auto)
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
        public static int GetTagLen(ReadOnlySpan<byte> buff, int offset)
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
        /// <returns>Decoded TAG.</returns>
        public static uint GetTag(ReadOnlySpan<byte> buff, int offset)
        {
            var len = GetTagLen(buff, offset);

            if (len > sizeof(uint))
            {
                throw new ArgumentOutOfRangeException($"TAGs longer than 4 bytes are not supported yet ({len})!");
            }

            uint ret = 0;
            for (int i = 0; i < len; i++)
            {
                ret <<= 8;
                ret |= buff[offset + i];
            }

            return ret;
        }
    }
}
