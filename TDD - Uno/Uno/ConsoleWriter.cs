using System;

namespace Uno
{
    public interface IConsoleWriter
    {
        void WriteToScreen(string text);
    }

    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteToScreen(string text)
        {
            Console.WriteLine(text);
        } 
    }
}