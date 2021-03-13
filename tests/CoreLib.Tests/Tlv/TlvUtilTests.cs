// <copyright file="TlvUtilTests.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace CoreLib.Tests.Tlv
{
    using System;
    using Jacarta.CoreLib.Convert;
    using Jacarta.CoreLib.Tlv;
    using NUnit.Framework;

    [TestFixture]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "This is only test fixture class.")]
    public class TlvUtilTests
    {
        [TestCase(0x0000007FU, Format.OneByteLength, 1)]
        [TestCase(0x000000FFU, Format.OneByteLength, 1)]
        [TestCase(0x00007FFFU, Format.TwoBytesLength, 2)]
        [TestCase(0x0000FFFFU, Format.TwoBytesLength, 2)]
        [TestCase(0x0000007FU, Format.Auto, 1)]
        [TestCase(0x00000080U, Format.Auto, 2)]
        [TestCase(0x000000FFU, Format.Auto, 2)]
        [TestCase(0x000001FFU, Format.Auto, 3)]
        [TestCase(0x00007FFFU, Format.Auto, 3)]
        [TestCase(0x0000FFFFU, Format.Auto, 3)]
        [TestCase(0x0001FFFFU, Format.Auto, 4)]
        [TestCase(0x007FFFFFU, Format.Auto, 4)]
        [TestCase(0x00FFFFFFU, Format.Auto, 4)]
        [TestCase(0x01FFFFFFU, Format.Auto, 5)]
        [TestCase(0x7FFFFFFFU, Format.Auto, 5)]
        [TestCase(0xFFFFFFFFU, Format.Auto, 5)]
        public void PositivePredictLengthLength(uint length, Format format, int expected)
        {
            var predictedLen = TlvUtil.PredictLengthLength(length, format);
            Assert.AreEqual(expected, predictedLen);
        }

        [TestCase(0x0000007FU, Format.OneByteLength, "7F")]
        [TestCase(0x000000FFU, Format.OneByteLength, "FF")]
        [TestCase(0x00007FFFU, Format.TwoBytesLength, "7FFF")]
        [TestCase(0x0000FFFFU, Format.TwoBytesLength, "FFFF")]
        [TestCase(0x0000007FU, Format.Auto, "7F")]
        [TestCase(0x00000080U, Format.Auto, "8180")]
        [TestCase(0x000000FFU, Format.Auto, "81FF")]
        [TestCase(0x000001FFU, Format.Auto, "8201FF")]
        [TestCase(0x00007FFFU, Format.Auto, "827FFF")]
        [TestCase(0x0000FFFFU, Format.Auto, "82FFFF")]
        [TestCase(0x0001FFFFU, Format.Auto, "8301FFFF")]
        [TestCase(0x007FFFFFU, Format.Auto, "837FFFFF")]
        [TestCase(0x00FFFFFFU, Format.Auto, "83FFFFFF")]
        [TestCase(0x01FFFFFFU, Format.Auto, "8401FFFFFF")]
        [TestCase(0x7FFFFFFFU, Format.Auto, "847FFFFFFF")]
        [TestCase(0xFFFFFFFFU, Format.Auto, "84FFFFFFFF")]
        public void PositiveEncodeLength(uint length, Format format, string expected)
        {
            var encoded = Hex.Encode(TlvUtil.EncodeLength(length, format), 0);
            Assert.IsTrue(string.Compare(expected, encoded, true) == 0);
        }

        [TestCase("00", 1)]
        [TestCase("01", 1)]
        [TestCase("7F", 1)]
        [TestCase("8190", 2)]
        [TestCase("821234", 3)]
        [TestCase("83123456", 4)]
        [TestCase("8412345678", 5)]
        public void PositiveTlvGetLengthFieldLen(string str, int expected)
        {
            var decoded = TlvUtil.GetLengthFieldLen(Hex.Decode(str), 0);
            Assert.AreEqual(expected, decoded);
        }

        [TestCase("00", 0U)]
        [TestCase("01", 1U)]
        [TestCase("7F", 0x7fU)]
        [TestCase("8190", 0x90U)]
        [TestCase("821234", 0x1234U)]
        [TestCase("83123456", 0x123456U)]
        [TestCase("8412345678", 0x12345678U)]
        public void PositiveTlvGetLengthNoValidation(string str, uint expected)
        {
            var decoded = TlvUtil.GetLength(Hex.Decode(str), 0);
            Assert.AreEqual(expected, decoded);
        }

        [TestCase("")]
        public void NegativeTlvGetLengthNoValidationIndexOutOfRange(string str)
        {
            Assert.Throws<IndexOutOfRangeException>(() => { TlvUtil.GetLength(Hex.Decode(str), 0); });
        }

        [TestCase("85")]
        [TestCase("FF")]
        public void NegativeTlvGetLengthNoValidation(string str)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { TlvUtil.GetLength(Hex.Decode(str), 0); });
        }

        [TestCase("C0", 1)]
        [TestCase("DF70", 2)]
        [TestCase("DF8570", 3)]
        public void PositiveTlvGetTagLen(string str, int expectedLen)
        {
            var tagLen = TlvUtil.GetTagLen(Hex.Decode(str), 0);
            Assert.AreEqual(expectedLen, tagLen);
        }

        [TestCase("C0", 0xC0U)]
        [TestCase("DF70", 0xDF70U)]
        [TestCase("DF8570", 0xDF8570U)]
        [TestCase("DF858870", 0xDF858870U)]
        public void PositiveTlvGetTag(string str, uint expectedTag)
        {
            var tag = TlvUtil.GetTag(Hex.Decode(str), 0);
            Assert.AreEqual(expectedTag, tag);
        }
    }
}
