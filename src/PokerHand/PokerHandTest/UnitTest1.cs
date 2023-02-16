//  Created by Hayden jin on 2023-02-16.
//  Copyright © 2023 Hayden jin. All rights reserved.
namespace PokerHandTest
{
    public class UnitTest1
    {
        public PokerHand.Card twoH = new PokerHand.Card(PokerHand.Suit.Hearts, PokerHand.Value.Two);
        public PokerHand.Card twoC = new PokerHand.Card(PokerHand.Suit.Clubs, PokerHand.Value.Two);
        public PokerHand.Card threeD = new PokerHand.Card(PokerHand.Suit.Diamonds, PokerHand.Value.Three);
        public PokerHand.Card fiveS = new PokerHand.Card(PokerHand.Suit.Spades, PokerHand.Value.Five);
        public PokerHand.Card nineC = new PokerHand.Card(PokerHand.Suit.Clubs, PokerHand.Value.Nine);
        public PokerHand.Card kingD = new PokerHand.Card(PokerHand.Suit.Diamonds, PokerHand.Value.King);
        public PokerHand.Card kingH = new PokerHand.Card(PokerHand.Suit.Hearts, PokerHand.Value.King);
        public PokerHand.Card fourS = new PokerHand.Card(PokerHand.Suit.Spades, PokerHand.Value.Four);
        public PokerHand.Card threeH = new PokerHand.Card(PokerHand.Suit.Hearts, PokerHand.Value.Three);
        public PokerHand.Card eightC = new PokerHand.Card(PokerHand.Suit.Clubs, PokerHand.Value.Eight);
        public PokerHand.Card aceH = new PokerHand.Card(PokerHand.Suit.Hearts, PokerHand.Value.Ace);
        public PokerHand.Card twoS = new PokerHand.Card(PokerHand.Suit.Spades, PokerHand.Value.Two);
        public PokerHand.Card jackC = new PokerHand.Card(PokerHand.Suit.Clubs, PokerHand.Value.Jack);
        public PokerHand.Card fourC = new PokerHand.Card(PokerHand.Suit.Clubs, PokerHand.Value.Four);
        public PokerHand.Card aceD = new PokerHand.Card(PokerHand.Suit.Diamonds, PokerHand.Value.Ace);
        public PokerHand.Card threeS = new PokerHand.Card(PokerHand.Suit.Spades, PokerHand.Value.Three);
        public PokerHand.Card sixS = new PokerHand.Card(PokerHand.Suit.Spades, PokerHand.Value.Six);
        public PokerHand.Card fourH = new PokerHand.Card(PokerHand.Suit.Hearts, PokerHand.Value.Four);
        public PokerHand.Card eightS = new PokerHand.Card(PokerHand.Suit.Spades, PokerHand.Value.Eight);
        public PokerHand.Card aceS = new PokerHand.Card(PokerHand.Suit.Spades, PokerHand.Value.Ace);
        public PokerHand.Card queenS = new PokerHand.Card(PokerHand.Suit.Spades, PokerHand.Value.Queen);
        public PokerHand.Card threeC = new PokerHand.Card(PokerHand.Suit.Clubs, PokerHand.Value.Three);
        public PokerHand.Card sevenC = new PokerHand.Card(PokerHand.Suit.Clubs, PokerHand.Value.Seven);
        public PokerHand.Card sixC = new PokerHand.Card(PokerHand.Suit.Clubs, PokerHand.Value.Six);
        public PokerHand.Card twoD = new PokerHand.Card(PokerHand.Suit.Diamonds, PokerHand.Value.Two);
        public PokerHand.Card fiveC = new PokerHand.Card(PokerHand.Suit.Clubs, PokerHand.Value.Five);
        public PokerHand.Card nineS = new PokerHand.Card(PokerHand.Suit.Spades, PokerHand.Value.Nine);

        [Fact]
        public void Test1()
        {

            var blackHand = new PokerHand.Hand(twoH, threeD, fiveS, nineC, kingD);

            var whiteHand = new PokerHand.Hand(twoC, threeH, fourS, eightC, aceH);

            var winner = new PokerHand.WinningHand(whiteHand, blackHand);

            Console.WriteLine(winner.getWinningHand());

            Assert.Equal(winner.getWinningHand(), "White hand wins by high card");

        }

        [Fact]
        public void Test2()
        {
            var blackHand = new PokerHand.Hand(twoC, twoS, aceH, jackC, fourC);

            var whiteHand = new PokerHand.Hand(aceH, aceD, twoH, threeS, sixS);

            var winner = new PokerHand.WinningHand(whiteHand, blackHand);

            Console.WriteLine(winner.getWinningHand());

            Assert.Equal(winner.getWinningHand(), "White hand wins by higher pair");
        }

        [Fact]
        public void Test3()
        {
            var blackHand = new PokerHand.Hand(twoH, fourS, fourC, threeD, fourH);

            var whiteHand = new PokerHand.Hand(twoS, eightS, aceS, queenS, threeS);

            var winner = new PokerHand.WinningHand(whiteHand, blackHand);

            Console.WriteLine(winner.getWinningHand());

            Assert.Equal(winner.getWinningHand(), "White hand wins by flush");
        }

        // BLACK: 2H 3D 5S 9C KD & WHITE: 2D 3H 5C 9S KH => TIE
        [Fact]
        public void Test4()
        {
            var blackHand = new PokerHand.Hand(threeC, sevenC, sixC, jackC, fourC);

            var whiteHand = new PokerHand.Hand(twoS, eightS, fourS, queenS, threeS);

            var winner = new PokerHand.WinningHand(whiteHand, blackHand);

            Console.WriteLine(winner.getWinningHand());

            Assert.Equal(winner.getWinningHand(), "White hand wins by higher flush");
        }
        [Fact]
        public void Test5()
        {
            var blackHand = new PokerHand.Hand(twoH, threeD, fiveS, nineC, kingD);

            var whiteHand = new PokerHand.Hand(twoC, threeH, fourS, eightC, kingH);

            var winner = new PokerHand.WinningHand(whiteHand, blackHand);

            Console.WriteLine(winner.getWinningHand());

            Assert.Equal(winner.getWinningHand(), "Black hand wins by high card");
        }
        [Fact]
        public void Test6()
        {
            var blackHand = new PokerHand.Hand(twoH, threeD, fiveS, nineC, kingD);

            var whiteHand = new PokerHand.Hand(twoD, threeH, fiveC, nineS, kingH);

            var winner = new PokerHand.WinningHand(whiteHand, blackHand);

            Console.WriteLine(winner.getWinningHand());

            Assert.Equal(winner.getWinningHand(), "Tie");
        }
    }
}