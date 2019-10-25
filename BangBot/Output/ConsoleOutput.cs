using System;

namespace BangBot.Output
{
    public class ConsoleOutput : IOutput
    {
        public void Write(params string[] messages)
        {
            foreach (string message in messages)
            {
                Console.WriteLine($"> {message}");    
            }
        }

        public void WritePrivate(string user, params string[] messages)
        {
            foreach (string message in messages)
            {
                Console.WriteLine($"> PRIVATE TO {user}: {message}");    
            }
        }
    }
}