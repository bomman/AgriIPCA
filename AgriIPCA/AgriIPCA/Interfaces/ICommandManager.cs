namespace AgriIPCA.Interfaces
{
    public interface ICommandManager
    {
        void PreLogInExecute(string[] command, ref bool isLoggedIn);
        void LogInExecute(string[] input, ref bool isLoggedIn);
    }
}
