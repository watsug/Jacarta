﻿// <copyright file="ResponseApdu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Jacarta.Smartcards.Iso7816
{
    using System;
    using Jacarta.CoreLib;

    public class ResponseApdu
    {
        /// <summary>
        /// Minimum length of R-APDU in bytes.
        /// </summary>
        public const int MinLength = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseApdu"/> class.
        /// </summary>
        /// <param name="sw">Status word.</param>
        /// <param name="data">R-APDU data.</param>
        public ResponseApdu(ushort sw, byte[] data)
        {
            SW = sw;
            Data = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseApdu"/> class.
        /// </summary>
        /// <param name="sw">Status word.</param>
        public ResponseApdu(ushort sw)
        {
            SW = sw;
            Data = Array.Empty<byte>();
        }

        /// <summary>
        /// Gets status word.
        /// </summary>
        public ushort SW { get; private set; }

        /// <summary>
        /// Gets R-APDU data.
        /// </summary>
        public byte[] Data { get; private set; }

        /// <summary>
        /// Constructs <see cref="ResponseApdu"/> object from buffer.
        /// </summary>
        /// <param name="buff">Input buffer.</param>
        /// <param name="offest">Offest of R-APDU.</param>
        /// <param name="length">Length of R-PAPDU (or -1 if all bytes till end of buffer).</param>
        /// <returns><see cref="ResponseApdu"/> object.</returns>
        public static ResponseApdu Factory(byte[] buff, int offest = 0, int length = -1)
        {
            length = length < 0 ? buff.Length - offest : length;

            if (length < MinLength)
            {
                throw new ArgumentException($"R-APDU needs to be at least {2}-bytes long!");
            }

            var sw = Util.GetUshort(buff, offest + length - MinLength);
            var data = Util.GetSubarray(buff, offest, length - MinLength);

            return new ResponseApdu(sw, data);
        }
    }
}
