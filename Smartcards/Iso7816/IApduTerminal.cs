namespace Jacarta.Smartcards.Iso7816
{
    public interface IApduTerminal
    {
        ResponseApdu Transmit(CommandApdu capdu);
    }
}
