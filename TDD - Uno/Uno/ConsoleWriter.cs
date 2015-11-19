using System;

namespace Uno
{
    public interface IConsoleWriter
    {
        void WriteToScreen(string text);
    }

    public class ConsoleWriter
    {
        public void WriteToScreen(string text)
        {
            Console.WriteLine(text);
        } 
    }
}