namespace Jacarta.Shell.Core
{
    public interface IShellCommand
    {
        void Execute(string parameters);
        void Help();
    }
}
