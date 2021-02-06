namespace Jacarta.Hal
{
    public interface ITerminal
    {
        byte[] Transmit(byte[] data);
    }
}
