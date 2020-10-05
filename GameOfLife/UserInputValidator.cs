using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    public class UserInputValidator
    {
        private Regex _numberRegex = new Regex(@"^-?\d+$");
        private Regex _rowColRegex = new Regex(@"^[1-9]+\,[1-9]+$");
        private const int maxQauntity = 1000;
        public UserInputValidator()
        {
        }

        public string HasQuantityInputerror(string userInput)
        {
            switch (userInput)
            {
                case string ui when ui == "":
                    return "Input cannot be blank.";
                case string ui when !_numberRegex.IsMatch(ui):
                    return "It is an invalid input.";
                case string ui when ConvertToNumber(ui) < 0:
                    return "Cannot be smaller than 1.";
                case string ui when ConvertToNumber(ui) > maxQauntity:
                    return "Cannot be larger than 1000.";
                default:
                    return "";
            }
        }

        public string HasLocationInputError(string userInput)
        {
            switch (userInput)
            {
                case string ui when ui == "":
                    return "Input cannot be blank.";
                case string ui when ui == "q":
                    return "";
                case string ui when !_rowColRegex.IsMatch(ui):
                    return "It is an invalid input.";
                default:
                    return "";
            }

        }

        public string HasLocationError(int[] locationDetails, Universe universe)
        {
            switch (locationDetails)
            {
                case int[] location when location.Length == 0:
                    return "";
                case int[] location when location[0] > universe.Row:
                    return "Row value of the live cell is outside of your universe.";
                case int[] location when location[1] > universe.Row:
                    return "Column value of the live cell is outside of your universe.";
                default:
                    return "";
            }

        }

        private int ConvertToNumber(string userInput)
        {
            return int.Parse(userInput);
        }


        public string HasExitError(int[] location, List<int[]> locationDetailsList)
        {
            if (location.Length == 0 && locationDetailsList.Count == 0)
            {
                return "Require at least one live cell in the universe";
            }
            return "";
        }

    }
}
