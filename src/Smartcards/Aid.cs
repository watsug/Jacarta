// <copyright file="Aid.cs" company="augustyn.net">
// Copyright (c) augustyn.net. All rights reserved.
// Licensed under GNU AFFERO GENERAL PUBLIC LICENSE Version 3, 19 November 2007
// </copyright>
// <author>Adam Augustyn</author>

namespace Jacarta.Smartcards
{
    using System.Collections.Generic;

    public class Aid
    {
        private static Dictionary<string, string> list;

        static Aid()
        {
            list = new Dictionary<string, string>()
            {
                { "A000000003000000", "(VISA) Card Manager" },
                { "A0000000035350", "OCS Oberthur Card System Security Domain Package AID / VGP Card Manager (for ISD and ASD)" },
                { "A0000001320001", "org.javacardforum.javacard.biometry" },
                { "A0000001510000", "Global Platform Security Domain AID" },
                { "A00000015153504341534400", "CASD_AID" },
            };
        }
    }
}
