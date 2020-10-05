using System;
namespace GameOfLife
{
    public class ConsoleAppInterface : InputOutput
    {
        public ConsoleAppInterface()
        {

        }
        public string Input()
        {
            return Console.ReadLine();
        }

        public void Output(string text)
        {
            Console.Write(text);
        }

    }
}
