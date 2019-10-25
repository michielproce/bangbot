using System;
using System.Linq;
using BangBot.Command;
using BangBot.Game;
using BangBot.Output;

namespace BangBot
{
    class Program
    {
        public static Random Random = new Random();
        
        static void Main(string[] args)
        {
            CommandProcessor commandProcessor = new CommandProcessor();
            
            // TODO write help if called without parameters
            
            if (args.ElementAtOrDefault(0) == "console")
            {
                Out.main = new ConsoleOutput();

                
                Out.main.Write(
                   "Console emulation mode",
                   "First word is person id, rest is command",
                   "For example, to start a game:",
                   "henk start"
                );
                
                
                Out.main.Write("");
                
                CommandProcessor processor = commandProcessor;
                
                if (args.ElementAtOrDefault(1) == "simulate")
                {
                    Random = new Random(12);
                    
                    Simulate(processor, "piet", "start");                        
                    Simulate(processor, "kees", "join");
                    
                    Simulate(processor, "henk", "join");                        
                    Simulate(processor, "anna", "join");                        
                    Simulate(processor, "emma", "join");                        
                    Simulate(processor, "lisa", "join");                        
                    Simulate(processor, "nick", "join");                        
                    Simulate(processor, "iris", "join");
                    Simulate(processor, "piet", "go");

                    string current = BangGame.Current.CurrentPlayer.User; 
                    Simulate(processor, current, "roll");                        
                    Simulate(processor, current, "roll 3");                        
                    Simulate(processor, current, "roll 14");
                    Simulate(processor, current, "done");                        
                }
                
                
                while (true)
                {
                    string command = Console.ReadLine();
                    
                    string[] commandSplit = command.Split(" ");
                    
                    if (commandSplit.Length < 2)
                    {
//                        Out.main.WriteLines("Invalid command");
                        continue;
                    }

                    processor.Process(commandSplit[0], command.Substring(command.IndexOf(" ") + 1));
                    
                }
            }
        }

        private static void Simulate(CommandProcessor processor, string user, string userCommand)
        {
            Console.WriteLine($"{user} {userCommand}");
            processor.Process(user, userCommand);
        }
    }
}