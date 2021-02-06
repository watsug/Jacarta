﻿// <copyright file="SW.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// </copyright>
// <author>Adam Augustyn</author>

namespace Jacarta.Smartcards.Iso7816
{
    using System.Collections.Generic;

    /// <summary>
    /// Definitions of typical ISO 7816-4 status words.
    /// </summary>
    public static class SW
    {
#pragma warning disable SA1600 // Elements should be documented
        public const int Ok = 0x9000;

        /// <summary>
        /// Warning processing.
        /// </summary>
        public const int EndOfFile = 0x6282;
        public const int LessDataRespondedThanRequested = 0x6287;

        /// <summary>
        /// Checking error.
        /// </summary>
        public const int WrongLength = 0x6700;

        public const int SecurityStatusNotSatisfied = 0x6982;
        public const int AuthenticationMethodBlocked = 0x6983;
        public const int DataInvalid = 0x6984;
        public const int ConditionsOfUseNotSatisfied = 0x6985;
        public const int CommandNotAllowed = 0x6986;
        public const int EcpectedSmDataObjectsMissing = 0x6987;
        public const int SmDataObjectsIncorrect = 0x6988;

        public const int WrongData = 0x6A80;
        public const int FuncNotSupported = 0x6A81;
        public const int FileNotFond = 0x6A82;
        public const int RecordNotFound = 0x6A83;
        public const int NotEnoughMemory = 0x6A84;
        public const int NcInconsistent = 0x6A85;
        public const int IncorrectP1P2 = 0x6A86;

        public const int ReferenceNotFound = 0x6A88;

        public const int WrongP1P2 = 0x6B00;
        public const int InsNotSupported = 0x6D00;
        public const int ClaNotSupported = 0x6E00;
        public const int NoPreciseDiagnosis = 0x6F00;
        public const int CardTerminated = 0x6FFF;

#pragma warning restore SA1600 // Elements should be documented

        private static Dictionary<ushort, string> _descriptions;

        static SW()
        {
            _descriptions = new Dictionary<ushort, string>()
            {
                { Ok, "Ok"},

                // Checking error.
                { RecordNotFound, "Record not found" },
                { NotEnoughMemory, "Not enough memory space in the file" },
                { NcInconsistent, "Nc inconsistent with TLV structure" },
                { IncorrectP1P2, "Incorrect parameters P1-P2" },
                { ReferenceNotFound, "Referenced data or reference data not found (exact meaning depending on the command)" },
                { WrongP1P2, "Wrong parameters P1-P2" },
                { InsNotSupported, "Instruction code not supported or invalid" },
                { ClaNotSupported, "Class not supported" },
                { NoPreciseDiagnosis, "No precise diagnosis" },
            };
        }

        public static string Translate(ushort sw)
        {
            if (_descriptions.ContainsKey(sw))
            {
                return _descriptions[sw];
            }

            return "";
        }
    }
}
