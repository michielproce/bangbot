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
                new RollCommand() 
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
            
//            if (firstSpace < 0)
//            {
//                firstSpace = userCommand.Length;
//            }
////            string parameters = userCommand.Substring(firstSpace + 1);
//

            foreach (ICommand command in _commands)
            {
                if (trigger == command.Trigger)
                {
                    command.Execute(user, parameters);
                    return;
                }
            }
        }
    }
}