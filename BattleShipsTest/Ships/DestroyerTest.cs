using BattleShipsBLL.Ships;
using BattleShipsBLL.Game.Utilities;
using BattleShipsBLLTest.Mock;
using System;
using System.Collections.Generic;
using Xunit;

namespace BattleShipsBLLTest.Ships
{
    
    public class DestroyerTest
    {
        
        [Theory]
        [MemberData(nameof(DestroyerTestData.GetData), MemberType = typeof(DestroyerTestData))]       
        public void ValidateDestroyer(bool[,] expectedShape)
        {
            Destroyer _Destroyer = new Destroyer();
            
            Assert.Equal(_Destroyer.GetShape(), expectedShape);
        }
    }
}
