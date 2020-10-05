using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            InputOutput io = new ConsoleAppInterface();
            Configuration configuration = new ManualConfiguration(io);
            var presenter = new ConsolePresenter(io);
            var game = new GameOfLife(configuration, presenter);
            game.Run();
        }
    }
}
