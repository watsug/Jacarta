﻿// <copyright file="Util.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace Jacarta.CoreLib
{
    using System;

    /// <summary>
    /// Utility class providing methods to simplify data processing.
    /// </summary>
    public class Util
    {
        /// <summary>
        /// Estract unsiged short value from byte array.
        /// </summary>
        /// <param name="buff">Input buffer.</param>
        /// <param name="off">Offeset.</param>
        /// <returns>Unsigned short value extracted form input buffer.</returns>
        public static ushort GetUShort(ReadOnlySpan<byte> buff, int off)
        {
            return (ushort)(buff[off] << 8 | buff[off + 1]);
        }

        /// <summary>
        /// Extracts sub-array.
        /// </summary>
        /// <param name="buff">Input buffer.</param>
        /// <param name="off">Offset.</param>
        /// <param name="len">Length (-1 if until the endo of buffer).</param>
        /// <returns>Sub-array.</returns>
        public static byte[] GetSubarray(ReadOnlySpan<byte> buff, int off, int len)
        {
            if (len == 0)
            {
                return Array.Empty<byte>();
            }

            return buff.Slice(off, len).ToArray();
        }
    }
}
