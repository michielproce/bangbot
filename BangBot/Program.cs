﻿using System;
using System.Linq;
using BangBot.Command;
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
                    Simulate(processor, "lisa", "leave");                        
                    Simulate(processor, "iris", "join");                        
//                    Simulate(processor, "piet", "go");                        
//                    Simulate(processor, "anna", "roll");                        
//                    Simulate(processor, "anna", "roll 35");                        
//                    Simulate(processor, "anna", "roll 6");                        
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
            Out.main.Write($"{user} {userCommand}");
            processor.Process(user, userCommand);
        }
    }
}