using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsBLLTest.Mock
{
    public class RandomMock : Random
    {
        private int __fixedInt = 0;
        private int __position = -1;
        private List<int> __fixedSequenceList = new List<int>();

        public RandomMock(int fixedInt) : base()
        {            
            __fixedInt = fixedInt;
            __fixedSequenceList.Add(__fixedInt);
        }

        public RandomMock(List<int> fixedSequence) : base()
        {
            if (fixedSequence == null)
                fixedSequence = new List<int>();

            __fixedSequenceList = fixedSequence;
            
            if (__fixedSequenceList.Count == 0)
            {
                __fixedSequenceList.Add(0);
            }
        }

        /// <summary>
        /// Mock the random number generator for testing
        /// </summary>        
        /// <returns></returns>
        public override int Next()
        {
            return Next(0);
        }

        /// <summary>
        /// Mock the random number generator for testing
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public override int Next(int maxValue)
        {
            __position++;

            if (__position >= __fixedSequenceList.Count)
            {
                __position = 0;
            }
            return __fixedSequenceList[__position];
        }       
    }
}
