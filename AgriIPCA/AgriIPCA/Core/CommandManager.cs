using System;
using AgriIPCA.Interfaces;
using AgriIPCA.Unitilies;

namespace AgriIPCA.Core
{
    public class CommandManager : ICommandManager
    {

        public CommandManager()
        {
            
        }

        public void PreLogInExecute(int command)
        {
            switch (command)
            {
                case 1:
                    PreLoginHelper.CreateAccount();
                    break;
                case 2:
                    PreLoginHelper.Login();
                    break;
                case 3:
                    Environment.Exit(1);
                    break;
                default:
                    throw new Exception("Invalid command.");
            }
        }

        private void CreateAccount()
        {
            
        }
    }
}
