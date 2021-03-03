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
        [Test]
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

        [Test]
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

        [Test]
        [TestCase("")]
        public void NegativeTlvGetLengthNoValidationIndexOutOfRange(string str)
        {
            Assert.Throws<IndexOutOfRangeException>(() => { TlvUtil.GetLength(Hex.Decode(str), 0); });
        }

        [Test]
        [TestCase("85")]
        [TestCase("FF")]
        public void NegativeTlvGetLengthNoValidation(string str)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { TlvUtil.GetLength(Hex.Decode(str), 0); });
        }

        [Test]
        [TestCase("C0", 1)]
        [TestCase("DF70", 2)]
        [TestCase("DF8570", 3)]
        public void PositiveTlvGetTagLen(string str, int expectedLen)
        {
            var tagLen = TlvUtil.GetTagLen(Hex.Decode(str), 0);
            Assert.AreEqual(expectedLen, tagLen);
        }

        [Test]
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
