using System;
using Xunit;
using Moq;
using System.Collections.Generic;

namespace GameOfLife.Test
{
    public class ManualConfigurationTest
    {
        public ManualConfigurationTest()
        {
        }

        [Theory]
        [InlineData(5)]
        public void ShouldReturnAUniverse(int quantity)
        {
            
            var mockio = new Mock<InputOutput>();
            mockio.Setup(x => x.Input()).Returns(quantity.ToString);
            var configuration = new ManualConfiguration(mockio.Object);
            var result = configuration.SetupUniverse();

            Assert.IsType<Universe>(result);
            Assert.True(result.Row == quantity);
            Assert.True(result.Col == quantity);
        }

        [Fact]
        public void ShouldReturnAListOfLocations()
        {
            var mockio = new Mock<InputOutput>();
            var universe = new Universe(5,5);
            mockio.SetupSequence(x => x.Input())
                .Returns("3,2")
                .Returns("3,3")
                .Returns("q");
            var configuration = new ManualConfiguration(mockio.Object);

            var result = configuration.SetInitalState(universe);
            Assert.IsType<List<Location>>(result);
            Assert.True(result.Count == 2);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(15)]
        public void ShouldReturnInteger(int quantity)
        {

            var mockio = new Mock<InputOutput>();
            mockio.Setup(x => x.Input()).Returns(quantity.ToString);
            var configuration = new ManualConfiguration(mockio.Object);
            var result = configuration.GetTermValue();

            Assert.True(result == quantity);
        }
    }
}
