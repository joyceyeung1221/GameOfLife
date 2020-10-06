using System;
using System.Collections.Generic;
using Xunit;
namespace GameOfLife.Test
{
    public class ExtensionMethodTest
    {
        public ExtensionMethodTest()
        {
        }

        [Fact]
        public void ShouldReturnTrue_WhenListContainsLocation()
        {
            var cd1 = new Location(1, 1);
            var cd2 = new Location(2, 2);
            var cd3 = new Location(4, 4);
            var list = new List<Location> { cd1, cd2 };
            var result = list.IsContained(cd1);

            Assert.True(list.IsContained(cd1));
            Assert.True(list.IsContained(cd2));
            Assert.False(list.IsContained(cd3));
        }
    }
}
