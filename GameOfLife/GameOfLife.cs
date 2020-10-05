using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    public class GameOfLife
    {
        private Configuration _configuration;
        private ConsolePresenter _presenter;
        public Universe Universe { get; private set; }
        private Generation _generation;
        private int _numberOfGeneration;

        public GameOfLife(Configuration configuration, ConsolePresenter presenter)
        {
            _configuration = configuration;
            _presenter = presenter;
        }

        public void Run()
        {
            SetupGameEnvironment();
            Process();
            AnnounceEndGame();
        }

        private void SetupGameEnvironment()
        {
            Universe = _configuration.SetupUniverse();
            List<Location> liveCellLocations = _configuration.SetInitalState(Universe);
            _numberOfGeneration = _configuration.GetTermValue();
            var locationConverter = new LocationConverter(Universe);
            _generation = new Generation(liveCellLocations, new TickProcessor(locationConverter));
        }

        private void Process()
        {
            bool endGame;
            int i = 1;
            _presenter.PrintUniverse(Universe, _generation.LiveCellLocations);
            do
            {
                _generation.Evolve();
                _presenter.PrintUniverse(Universe, _generation.LiveCellLocations);
                endGame = CanEndGame();
                i++;
            } while (i <= _numberOfGeneration && !endGame);
        }

        private void AnnounceEndGame()
        {
            _presenter.EndGame();
        }

        private bool CanEndGame()
        {
            return _generation.LiveCellLocations.Count == 0;
        }
    }
}
