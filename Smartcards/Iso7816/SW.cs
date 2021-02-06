// <copyright file="SW.cs" company="augustyn.net">
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

        // Warning processing.
        // 62xx
        public const int NoInformationGiven6200 = 0x6200;
        public const int PartOfDataCorrupted = 0x6281;
        public const int EndOfFile = 0x6282;
        public const int SelectedFileDeactivated = 0x6283;
        public const int FciImproper = 0x6284;
        public const int SelectedFileTerminated = 0x6285;
        public const int NoInputDataFromSensor = 0x6286;
        public const int LessDataRespondedThanRequested = 0x6287;

        // 63xx
        public const int NoInformationGiven6300 = 0x6300;
        public const int FileFilledUp = 0x6381;

        // Checking errors.
        // 64xx
        public const int ExecutionError = 0x6400;
        public const int ImmediateResponseRequired = 0x6401;

        // 65xx
        public const int NoInformationGiven6500 = 0x6500;
        public const int MemoryFailure = 0x6581;

        public const int WrongLength = 0x6700;

        // 69xx
        public const int CommandIncompatible = 0x6981;
        public const int SecurityStatusNotSatisfied = 0x6982;
        public const int AuthenticationMethodBlocked = 0x6983;
        public const int DataNotUsable = 0x6984;
        public const int ConditionsOfUseNotSatisfied = 0x6985;
        public const int CommandNotAllowed = 0x6986;
        public const int ExpectedSmDataObjectsMissing = 0x6987;
        public const int IncorrectSmDataObjects = 0x6988;

        // 6Axx
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
                { Ok, "Ok" },

                // Warning processing.
                // 62xx
                { NoInformationGiven6200, "No information given ('6200')" },
                { PartOfDataCorrupted, "Part of returned data may be corrupted" },
                { EndOfFile, "End of file or record reached before reading Ne bytes" },
                { SelectedFileDeactivated, "Selected file deactivated" },
                { FciImproper, "File control information not formatted according to 5.3.3" },
                { SelectedFileTerminated, "Selected file in termination state" },
                { NoInputDataFromSensor, "No input data available from a sensor on the card" },
                { LessDataRespondedThanRequested, "Less data responded than requested" },

                // 63xx
                { NoInformationGiven6300, "No information given ('6300')" },
                { FileFilledUp, "File filled up by the last write" },

                // Checking errors.
                // 64xx
                { ExecutionError, "Execution error" },
                { ImmediateResponseRequired, "Immediate response required by the card" },

                // 65xx
                { NoInformationGiven6500, "No information given ('6500')" },
                { MemoryFailure, "Memory failure" },

                // 6700
                { WrongLength, "Wrong length; no further indication" },

                // 69xx
                { CommandIncompatible, "Command incompatible with file structure" },
                { SecurityStatusNotSatisfied, "Security status not satisfied" },
                { AuthenticationMethodBlocked, "Authentication method blocked" },
                { DataNotUsable, "Reference data not usable" },
                { ConditionsOfUseNotSatisfied, "Conditions of use not satisfied" },
                { CommandNotAllowed, "Command not allowed (no current EF)" },
                { ExpectedSmDataObjectsMissing, "Expected secure messaging data objects missing" },
                { IncorrectSmDataObjects, "Incorrect secure messaging data objects" },

                // 6Axx
                { WrongData, "Incorrect parameters in the command data field" },
                { FuncNotSupported, "Function not supported" },
                { FileNotFond, "File or application not found" },
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

        /// <summary>
        /// Translates numerical value of SW to known string.
        /// </summary>
        /// <param name="sw">Status word.</param>
        /// <returns>Description.</returns>
        public static string Translate(ushort sw)
        {
            if (_descriptions.ContainsKey(sw))
            {
                return _descriptions[sw];
            }

            return $"{sw:X04h}";
        }
    }
}
