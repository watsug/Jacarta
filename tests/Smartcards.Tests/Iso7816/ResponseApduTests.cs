// <copyright file="ResponseApduTests.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace Smartcards.Tests.Iso7816
{
    using Jacarta.CoreLib.Convert;
    using Jacarta.Smartcards.Iso7816;
    using NUnit.Framework;
    using System;

    [TestFixture]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "This is only test fixture class.")]
    public class ResponseApduTests
    {
        [Test]
        [TestCase("6A80", 0x6A80, "")]
        [TestCase("1234569000", 0x9000, "123456")]
        public void PositiveResponseApduFactory(string str, int expectedSw, string expectedData)
        {
            var rApdu = ResponseApdu.Factory(Hex.Decode(str));
            Assert.AreEqual((ushort)expectedSw, rApdu.SW);
            StringAssert.AreEqualIgnoringCase(expectedData, Hex.Encode(rApdu.Data, 0));
        }

        [Test]
        [TestCase("")]
        [TestCase("6F")]
        public void NegativeResponseApduFactoryWrongData(string str)
        {
            Assert.Throws<ArgumentException>(() => ResponseApdu.Factory(Hex.Decode(str)));
        }
    }
}
