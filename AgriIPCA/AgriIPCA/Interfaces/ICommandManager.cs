namespace AgriIPCA.Interfaces
{
    public interface ICommandManager
    {
        void PreLogInExecute(int command, out bool isLoggedIn);
        void LogInExecute(int input, out bool isLoggedIn);
    }
}
