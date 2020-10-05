using System;
using Xunit;
namespace GameOfLife.Test
{
    public class UserInputValidatorTest
    {
        private UserInputValidator _uiValidator;
        private Universe universe = new Universe(5, 5);
        public UserInputValidatorTest()
        {
            _uiValidator = new UserInputValidator();
        }


        [Theory]
        [InlineData("1","")]
        [InlineData("", "Input cannot be blank.")]
        [InlineData("100000", "Cannot be larger than 1000.")]
        [InlineData("fdfsdf", "It is an invalid input.")]
        [InlineData("-1", "Cannot be smaller than 1.")]
        [InlineData("1.04324", "It is an invalid input.")]
        public void ShouldReturnErrorMessage_WhenUserInputForUniverseRecorded(string userInput, string expected)
        {
            Assert.Equal(expected, _uiValidator.HasQuantityInputError(userInput));
        }

        [Theory]
        [InlineData("1,1", "")]
        [InlineData("", "Input cannot be blank.")]
        [InlineData("0,1", "It is an invalid input.")]
        [InlineData("fdsf,1", "It is an invalid input.")]
        [InlineData("1", "It is an invalid input.")]
        [InlineData("1,-11", "It is an invalid input.")]
        [InlineData("1.1", "It is an invalid input.")]
        public void ShouldReturnErrorMessage_WhenUserInputForLiveCellRecorded(string userInput, string expected)
        {
            Assert.Equal(expected, _uiValidator.HasLocationInputError(userInput));
        }

        [Theory]
        [InlineData(1,2,"")]
        [InlineData(7,2, "Row value of the live cell is outside of your universe.")]
        [InlineData(1,50, "Column value of the live cell is outside of your universe.")]
        public void ShouldReturnErrorMessage_WhenLiveCellLocationEntered(int row, int col, string expected)
        {
            var array = new int[] { row, col };
            Assert.Equal(expected, _uiValidator.HasLocationError(array, universe));
        }

    }
}
