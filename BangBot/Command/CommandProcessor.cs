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
                new GoCommand() 
            };
        }

        public void Process(string user, string userCommand)
        {
            userCommand = userCommand.Trim().ToLower();
            
            foreach (ICommand command in _commands)
            {
                if (userCommand == command.Trigger)
                {
                    command.Execute(user, userCommand);

                    return;
                }
            }
        }
    }
}