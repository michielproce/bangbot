using System;

namespace BangBot.Output
{
    public class ConsoleOutput : IOutput
    {
        public void WriteLines(params string[] ss)
        {
            foreach (string s in ss)
            {
                Console.WriteLine(s);    
            }
        }
    }
}