// <copyright file="TlvDataAttribute.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace Jacarta.CoreLib.Tlv
{
    using System;

    /// <summary>
    /// TaggedData attribute used to serialize TLV structures.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1309:Field names should not begin with underscore", Justification = "Readibility")]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TlvDataAttribute : LvDataAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TlvDataAttribute"/> class.
        /// </summary>
        /// <param name="index">Index in TLV encoded data.</param>
        /// <param name="tag">TAG number.</param>
        /// <param name="format">Format to encode the length.</param>
        public TlvDataAttribute(int index, uint tag, Format format = Format.Auto)
            : base(index, format)
        {
            Tag = tag;
        }

        /// <summary>
        /// Gets format to encode length field.
        /// </summary>
        private uint Tag { get; }
    }
}
