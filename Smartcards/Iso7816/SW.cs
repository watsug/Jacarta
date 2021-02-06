namespace Jacarta.Smartcards.Iso7816
{
    public static class SW
    {
        public const int Ok = 0x9000;

        public const int EndOfFile = 0x6282;
        public const int LessDataRespondedThanRequested = 0x6287;

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
        public const int FileFull = 0x6A84;
        public const int OutOfMemory = 0x6A84;
        public const int IncorrectP1P2 = 0x6A86;
        public const int KeyNotFound = 0x6A88;

        public const int WrongP1P2 = 0x6B00;

        public const int InsNotSupported = 0x6D00;
        public const int ClaNotSupported = 0x6E00;
        public const int NoPreciseDiagnosis = 0x6F00;
        public const int CardTerminated = 0x6FFF;
    }
}
