// <copyright file="LvDataAttribute.cs" company="augustyn.net">
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
    public class LvDataAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LvDataAttribute"/> class.
        /// </summary>
        /// <param name="index">Index in TLV encoded data.</param>
        /// <param name="format">Format to encode the length.</param>
        public LvDataAttribute(int index, Format format = Format.Auto)
        {
            Index = index;
            Format = format;
        }

        /// <summary>
        /// Gets index in TLV structure (starting from 0).
        /// </summary>
        private int Index { get; }

        /// <summary>
        /// Gets format to encode length field.
        /// </summary>
        private Format Format { get; }
    }
}
