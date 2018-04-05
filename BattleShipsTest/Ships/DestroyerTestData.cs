using BattleShipsBLL.Ships;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsBLLTest.Ships
{
    public class DestroyerTestData
    {
        private static bool[,] __shape = new bool[2, 2] { { true, true }, { true, true } };
        
        public static IEnumerable<object[]> GetData =>
        new List<object[]>
        {
            new object[] { __shape },
        };
    }
}
