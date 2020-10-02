using System;
namespace GameOfLife
{
    public class ConsoleInterface : InputOutput
    {
        public ConsoleInterface()
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
