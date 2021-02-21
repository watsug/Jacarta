// <copyright file="Hex.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace Jacarta.CoreLib.Convert
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Class providing base-16 (hex) encoding / decoding methods.
    /// </summary>
    public static class Hex
    {
        /// <summary>
        /// Byte to hex map.
        /// </summary>
        public const string HexTemplate = "0123456789ABCDEF";

        /// <summary>
        /// Encodes bytes buffer int base-16 (hex) string.
        /// </summary>
        /// <param name="buff">Input buffer.</param>
        /// <param name="offset">Offset in the input buffer.</param>
        /// <param name="length">Lenght of data to be encoded.</param>
        /// <returns>Base-16 (hex) string.</returns>
        public static string Encode(ReadOnlySpan<byte> buff, int offset, int length = -1)
        {
            if (length < 0)
            {
                length = buff.Length - offset;
            }

            if (length == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder(length * 2);
            for (int i = offset; i < offset + length; i++)
            {
                var b = buff[i];
                sb.Append(HexTemplate[b >> 4]);
                sb.Append(HexTemplate[b & 0x0f]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Encodes bytes buffer int base-16 (hex) string.
        /// </summary>
        /// <param name="stream">Output stream.</param>
        /// <param name="buff">Input buffer.</param>
        /// <param name="offset">Offset in the input buffer.</param>
        /// <param name="length">Lenght of data to be encoded.</param>
        public static void Encode(Stream stream, ReadOnlySpan<byte> buff, int offset, int length = -1)
        {
            if (length < 0)
            {
                length = buff.Length - offset;
            }

            if (length == 0)
            {
                return;
            }

            using (TextWriter tw = new StreamWriter(stream))
            {
                for (int i = offset; i < offset + length; i++)
                {
                    var b = buff[i];
                    tw.Write(HexTemplate[b >> 4]);
                    tw.Write(HexTemplate[b & 0x0f]);
                }
            }
        }

        /// <summary>
        /// Decodes base-16 (hex) string into bytes.
        /// </summary>
        /// <param name="str">Input string.</param>
        /// <returns>Bytes.</returns>
        public static byte[] Decode(string str)
        {
            if (str.Length % 2 != 0)
            {
                throw new ArgumentException($"Input base-16 (hex) string must be modulo 2!");
            }

            if (str.Length == 0)
            {
                return Array.Empty<byte>();
            }

            var buff = new byte[str.Length / 2];
            for (int i = 0, j = 0; j < str.Length; i++, j += 2)
            {
                var b1 = DecodeChar(str[j]);
                var b2 = DecodeChar(str[j + 1]);
                buff[i] = (byte)(((b1 << 4) & 0xf0) | b2);
            }

            return buff;
        }

        private static byte DecodeChar(char ch)
        {
            if (ch >= '0' && ch <= '9')
            {
                return (byte)(ch - '0');
            }
            else if (ch >= 'a' && ch <= 'f')
            {
                return (byte)(10 + (ch - 'a'));
            }
            else if (ch >= 'A' && ch <= 'F')
            {
                return (byte)(10 + (ch - 'A'));
            }

            throw new ArgumentException($"Character '{ch}' cannot be translated into base-16 nibble!");
        }
    }
}
