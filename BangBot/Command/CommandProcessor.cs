using System.Linq;
using BangBot.Game;

namespace BangBot.Command
{
    public class CommandProcessor
    {
        private readonly ICommand[] _commands;
        
        public CommandProcessor()
        {
            _commands = new ICommand[]
            {
                new StartGameCommand(),
                new JoinGameCommand(), 
                new GoCommand(),
                new RollCommand(),
                new ShowCommand()
            };
        }

        public void Process(string user, string userCommand)
        {
            userCommand = userCommand.Trim().ToLower();
            
            int firstSpace = userCommand.IndexOf(" ");
            
            string trigger;
            string parameters = null;
            
            if (firstSpace < 0)
            {
                trigger = userCommand;
            }
            else
            {
                trigger = userCommand.Substring(0, firstSpace);
                parameters = userCommand.Substring(firstSpace + 1);
            }

            ICommand command = _commands.SingleOrDefault(o => o.Trigger == trigger);

            if (command != null)
            {
                if (command.RequiredGameState.HasValue)
                {
                    if (BangGame.Current.State != command.RequiredGameState)
                    {
                        return;
                    }
                }

                if (command.OnlyForCurrentUser)
                {
                    Player player = BangGame.Current?.CurrentPlayer;
                    if (user != player?.User)
                    {
                        return;
                    }
                        
                }

                command.Execute(user, parameters);
            }
        }
    }
}