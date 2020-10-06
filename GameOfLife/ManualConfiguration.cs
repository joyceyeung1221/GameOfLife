using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class ManualConfiguration : Configuration
    {
        private UserInputValidator _uiValidator;
        private InputOutput _io;
        public ManualConfiguration(InputOutput io)
        {
            _uiValidator = new UserInputValidator();
            _io = io;
        }

        public int GetTermValue()
        {
            return GetQuantity($"Please define tha maximum generations of the live cell: ");
        }

        public Universe SetupUniverse()
        {
            var row = GetQuantity("Please enter the number of rows your universe has: ");
            var column = GetQuantity("Please enter the number of columns your universe has: ");
            return new Universe(row, column);
        }

        private int GetQuantity(string message)
        {
            string userInput;
            string errorMessage;
            do
            {
                errorMessage = "";
                _io.Output(message);
                userInput = _io.Input();
                errorMessage = _uiValidator.HasQuantityInputError(userInput);
                CanPrintErrorMessage(errorMessage);
            } while (errorMessage != "");

            return Int32.Parse(userInput);
        }

        public List<Location> SetInitalState(Universe universe)
        {
            var locationDetailsList = GetInitalStateLocationDetails(universe);
            var liveCellLocationList = GenerateLocation(locationDetailsList);

            return RemoveDuplicateCoordinate(liveCellLocationList);
        }

        private List<int[]> GetInitalStateLocationDetails(Universe universe)
        {
            string errorMessage;
            bool isEnded = false;
            var locationDetailsList = new List<int[]>();
            do
            {
                errorMessage = "";
                var userInput = GetUserInputOnLiveCellLocation();
                var location = ConvertToLocation(userInput);
                errorMessage = _uiValidator.HasLocationError(location, universe);
                CanAdd(location, locationDetailsList);
                var exitError = _uiValidator.HasExitError(location, locationDetailsList);
                if (exitError == "" && location.Length == 0)
                {
                    isEnded = true;
                }
                errorMessage += exitError;
                CanPrintErrorMessage(errorMessage);
            } while (!isEnded);

            return locationDetailsList;

        }

        private int[] ConvertToLocation(string userInput)
        {
            if (userInput == "q")
            {
                return new int[0];
            }

            var splitInput = userInput.Split(',');
            return new int[] { Int32.Parse(splitInput[0]), Int32.Parse(splitInput[1]) };

        }

        private List<int[]> CanAdd(int[] locationDetails, List<int[]> locationDetailsList)
        {
            if (locationDetails.Length > 0)
            {
                locationDetailsList.Add(locationDetails);
            }
            return locationDetailsList;
        }

        private string GetUserInputOnLiveCellLocation()
        {
            string errorMessage;
            string userInput;
            do
            {
                errorMessage = "";
                _io.Output($"Please enter location details for each live cell in row:column format (eg. 1,2)\n");
                _io.Output("Enter 'q' to end recording: ");
                userInput = _io.Input();
                errorMessage = _uiValidator.HasLocationInputError(userInput);
                CanPrintErrorMessage(errorMessage);
            } while (errorMessage != "");
            return userInput;
        }

        private List<Location> GenerateLocation(List<int[]> locationDetailsList)
        {
            List<Location> locationList = new List<Location>();
            foreach (int[] location in locationDetailsList)
            {
                locationList.Add(new Location(location[0], location[1]));
            }
            return locationList;
        }

        private List<Location> RemoveDuplicateCoordinate(List<Location> locations)
        {
            var filterList = locations.GroupBy(n => new { n.Column, n.Row }).Select(g => g.First()).ToList();
            return filterList;
        }

        private void CanPrintErrorMessage(string errorMessage)
        {
            if (errorMessage != "")
            {
                _io.Output(errorMessage);
            }
        }
    }
}
