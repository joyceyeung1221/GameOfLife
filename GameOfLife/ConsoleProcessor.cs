using System;
namespace GameOfLife
{
    public class ConsoleProcessor : InputOutput
    {
        public ConsoleProcessor()
        {

        }
        public string Input()
        {
            return Console.ReadLine();
        }

        public void Output(string text)
        {
            Console.WriteLine(text);
        }

    }
}
