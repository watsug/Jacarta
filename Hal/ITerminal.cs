// <copyright file="ITerminal.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Jacarta.Hal
{
    public interface ITerminal
    {
        byte[] Transmit(byte[] data);
    }
}
