// <copyright file="TlvDataTests.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace CoreLib.Tests.Tlv
{
    using Jacarta.CoreLib.Convert;
    using Jacarta.CoreLib.Tlv;
    using NUnit.Framework;

    [TestFixture]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "This is only test fixture class.")]
    public class TlvDataTests
    {
        [TestCase(0xC0U, "1234", Format.Der, "C0021234")]
        public void PositiveEncodeLength(uint tag, string data, Format format, string expected)
        {
            var encoded = Hex.Encode(new TlvData(tag, Hex.Decode(data)).Encode(format), 0);
            Assert.IsTrue(string.Compare(expected, encoded, true) == 0);
        }
    }
}
