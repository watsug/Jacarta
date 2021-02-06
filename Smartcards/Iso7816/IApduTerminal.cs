// <copyright file="IApduTerminal.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Jacarta.Smartcards.Iso7816
{
    public interface IApduTerminal
    {
        ResponseApdu Transmit(CommandApdu capdu);
    }
}
