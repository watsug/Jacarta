namespace Jacarta.Smartcards.Iso7816
{
    using Jacarta.CoreLib;
    using System;

    public class ResponseApdu
    {
        public const int MinLength = 2;

        public ResponseApdu(ushort sw, byte[] data)
        {
            SW = sw;
            Data = data;
        }

        public ResponseApdu(ushort sw)
        {
            SW = sw;
            Data = Array.Empty<byte>();
        }

        public ushort SW { get; private set; }
        public byte[] Data { get; private set; }


        public static ResponseApdu Factory(byte[] buff, int offest = 0, int length = -1)
        {
            length = length < 0 ? buff.Length - offest : length;

            if (length < MinLength)
            {
                throw new ArgumentException($"R-APDU needs to be at least {2}-bytes long!");
            }

            var sw = Util.GetUshort(buff, offest + length - MinLength);
            var data = Util.GetSubarray(buff, offest, length - MinLength);

            return new ResponseApdu(sw, data);
        }
    }
}
