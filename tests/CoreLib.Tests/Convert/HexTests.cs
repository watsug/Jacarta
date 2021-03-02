// <copyright file="HexTests.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace CoreLib.Tests.Convert
{
    using System;
    using System.Linq;
    using Jacarta.CoreLib.Convert;
    using NUnit.Framework;

    [TestFixture]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "This is only test fixture class.")]
    public class HexTests
    {
        [Test]
        [TestCase("", new byte[] { })]
        [TestCase("A0", new byte[] { 0xA0 })]
        [TestCase("1234567890", new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90 })]
        [TestCase("ABCDEF", new byte[] { 0xAB, 0xCD, 0xEF })]
        [TestCase("abcdef", new byte[] { 0xAB, 0xCD, 0xEF })]
        public void PositiveHexDecode(string str, byte[] expected)
        {
            var decoded = Hex.Decode(str);
            Assert.IsTrue(expected.SequenceEqual(decoded));
        }

        [Test]
        [TestCase("1")]
        [TestCase("A")]
        [TestCase("123")]
        [TestCase("ABC")]
        [TestCase("abc")]
        [TestCase("ABCG")]
        [TestCase("abcgef")]
        public void NegativeHexDecode(string str)
        {
            Assert.Throws<ArgumentException>(() => { Hex.Decode(str); });
        }

        [Test]
        [TestCase(new byte[] { }, "")]
        [TestCase(new byte[] { 0xA0 }, "A0")]
        [TestCase(new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90 }, "1234567890")]
        [TestCase(new byte[] { 0xAB, 0xCD, 0xEF }, "ABCDEF")]
        public void PositiveHexEncode(byte[] data, string expected)
        {
            var encoded = Hex.Encode(data, 0);
            Assert.IsTrue(string.Compare(expected, encoded, true) == 0);
        }
    }
}
