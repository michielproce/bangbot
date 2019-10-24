using System;
using BangBot.Command;
using BangBot.Output;

namespace BangBot
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandProcessor commandProcessor = new CommandProcessor();
            
            // TODO write help if called without parameters
            
            if (args[0] == "console")
            {
                Out.main = new ConsoleOutput();

                
                Out.main.WriteLines(
                   "Console emulation mode",
                   "First word is person id, rest is command",
                   "For example, to start a game:",
                   "henk start"
                );
                
                
                Out.main.WriteLines("");
                
                CommandProcessor processor = commandProcessor;
                
                if (args[1] == "simulate-start")
                {
                    Simulate(processor, "piet", "start");                        
                    Simulate(processor, "kees", "join");                        
                    Simulate(processor, "henk", "join");                        
                    Simulate(processor, "sanne", "join");                        
                    Simulate(processor, "emma", "join");                        
                    Simulate(processor, "lisa", "join");                        
                    Simulate(processor, "nick", "join");                        
                    Simulate(processor, "iris", "join");                        
                    Simulate(processor, "piet", "go");                        
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
            Out.main.WriteLines($"{user} {userCommand}");
            processor.Process(user, userCommand);
        }
    }
}