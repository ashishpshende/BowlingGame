using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling_ball_scoring
{
    class BowlingGameTest
    {
         private Game g;

        public BowlingGameTest()
        {
            g = new Game();
        }

        private void rollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }

        private void rollSpare()
        {
            g.Roll(6);
            g.Roll(4);
        }

        
        public void TestBowlingGameClass()
        {
            Assert.IsType<Game>(g);
        }

        
        public void TestGutterGame()
        {
            rollMany(20, 0);
            Assert.Equal(0, g.Score());
        }

        
        public void TestAllOnes()
        {
            rollMany(20, 1);
            Assert.Equal(20, g.Score());
        }

        
        public void TestOneSpare()
        {
            rollSpare();
            g.Roll(4);
            rollMany(17, 0);
            Assert.Equal(18, g.Score());
        }

        
        public void TestOneStrike()
        {
            g.Roll(10);
            g.Roll(4);
            g.Roll(5);
            rollMany(17, 0);
            Assert.Equal(28, g.Score());
        }

        
        public void TestPerfectGame()
        {
            rollMany(12, 10);
            Assert.Equal(300, g.Score());
        }

        
        public void TestRandomGameNoExtraRoll()
        {
            g.Roll(new int[] { 4, 3, 6, 1, 6, 9, 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3 });
            Assert.Equal(131, g.Score());
        }

        
        public void TestRandomGameWithSpareThenStrikeAtEnd()
        {
            g.Roll(new int[] { 2, 10, 9, 1, 10 , 5, 2, 5, 3, 8, 2, 8, 1, 3, 7, 3, 10, 1, 7});
            Assert.Equal(143, g.Score());
        }

        
        public void TestRandomGameWithThreeStrikesAtEnd()
        {
            g.Roll(new int[] { 8, 2, 10, 10, 10, 10, 7, 5, 2, 5, 3, 8, 2, 1, 3, 7, 3, 10, 1});
            Assert.Equal(163, g.Score());
        }

    }
}
