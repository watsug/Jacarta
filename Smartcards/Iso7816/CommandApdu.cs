
namespace Jacarta.Smartcards.Iso7816
{
    using System;

    public class CommandApdu
    {
        public CommandApdu(int cla, int cmd, int p1, int p2, byte[] data, int le)
        {
        }

        public CommandApdu(int cla, int cmd, int p1, int p2, byte[] data)
            : this(cla, cmd, p1, p2, data, -1)
        {
        }

        public CommandApdu(int cla, int cmd, int p1, int p2)
            : this(cla, cmd, p1, p2, Array.Empty<byte>())
        {
        }
    }
}
