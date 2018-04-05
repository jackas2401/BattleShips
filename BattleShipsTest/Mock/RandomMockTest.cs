using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleShipsBLLTest.Mock
{
    public class RandomMockTest
    {
        [Fact]
        public void DefaultConstructorSingleValue()
        {
            RandomMock _randomMock = new RandomMock(0);

            Assert.True(_randomMock.Next() == 0);
        }

        [Fact]
        public void ConstructorNullList()
        {
            RandomMock _randomMock = new RandomMock(null);

            Assert.True(_randomMock.Next() == 0);
        }

        [Fact]
        public void ConstructorEmptyList()
        {
            RandomMock _randomMock = new RandomMock(new List<int> { });

            Assert.True(_randomMock.Next() == 0);
        }

        [Fact]
        public void NextMethodListCompare()
        {
            List<int> _inputSequence = new List<int> { 1, 2, 3, 4 };
            List<int> _outputSequence = new List<int>();

            RandomMock _randomMock = new RandomMock(_inputSequence);

            foreach (int number in _inputSequence)
            {
                _outputSequence.Add(_randomMock.Next());
            }
            
            Assert.Equal(_inputSequence, _outputSequence);
        }
    }
}
