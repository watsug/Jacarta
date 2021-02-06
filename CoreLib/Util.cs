// <copyright file="Util.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Jacarta.CoreLib
{
    using System;

    public class Util
    {
        public static ushort GetUshort(byte[] buff, int off)
        {
            return (ushort)(buff[off] << 8 | buff[off + 1]);
        }

        public static byte[] GetSubarray(byte[] buff, int off, int len)
        {
            if (len == 0)
            {
                return Array.Empty<byte>();
            }

            byte[] tmp = new byte[len];
            Array.Copy(buff, off, tmp, 0, len);
            return tmp;
        }
    }
}
