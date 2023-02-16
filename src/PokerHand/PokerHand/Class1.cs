//  Created by Hayden jin on 2023-02-16.
//  Copyright © 2023 Hayden jin. All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHand
{
    public enum Suit
    {
        Diamonds,
        Hearts,
        Spades,
        Clubs
    }

    public enum Value
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }
    public class Card
    {
        public Suit suit { get; }
        public Value value { get; }

        public Card(Suit suit, Value value)
        {
            this.suit = suit;
            this.value = value;
        }
    }

    public class Hand
    {
        public List<Card> cards { get; } = new List<Card>();

        public Hand(params Card[] cards)
        {
            if (cards.Length != 5)
            {
                throw new ArgumentException("A hand must have 5 cards");
            }

            this.cards.AddRange(cards);
        }

        public List<int> isFlush()
        {

            List<int> returnInts = new List<int>();

            // If there is only one suit then we have a flush
            if (this.cards.Select(card => card.suit).Distinct().Count() == 1)
            {
                returnInts.Add((int)cards.Max(card => card.value));
                return returnInts;
            }

            return null;
        }

        public List<int> threeOfAKind()
        {

            List<int> returnInts = new List<int>();

            // Check if there is a group of 3 and return the value 
            var groups = this.cards.GroupBy(c => c.value);
            foreach (var group in groups)
            {
                if (group.Count() == 3)
                {
                    returnInts.Add((int)group.Key);
                    return returnInts;
                }
            }
            return null;
        }

        public List<int> twoPair()
        {
            // Check if there is 2 groups of 2 and return the values 
            var groups = this.cards.GroupBy(c => c.value);

            List<int> returnInts = new List<int>();

            if (groups.Count() != 3)
            {
                return null;
            }

            foreach (var group in groups)
            {
                if (group.Count() == 2)
                {
                    returnInts.Add((int)group.Key);
                }
            }

            foreach (var group in groups)
            {
                if (group.Count() == 1)
                {
                    returnInts.Add((int)group.Key);
                }
            }

            if (returnInts.Count == 3)
            {
                return returnInts;
            }

            return null;
        }

        public List<int> onePair()
        {
            // Check if there is 1 group of 2 and return the values 
            var groups = this.cards.GroupBy(c => c.value);

            List<int> returnInts = new List<int>();

            if (groups.Count() != 4)
            {
                return null;
            }

            foreach (var group in groups)
            {
                if (group.Count() == 2)
                {
                    returnInts.Add((int)group.Key);
                }
            }

            List<int> singles = new List<int>();

            foreach (var group in groups)
            {
                if (group.Count() == 1)
                {
                    singles.Add((int)group.Key);
                }
            }

            singles.Sort();
            singles.Reverse();

            foreach (var item in singles)
            {
                returnInts.Add(item);
            }

            if (returnInts.Count == 4)
            {
                return returnInts;
            }

            return null;
        }

        public List<int> highestValue()
        {
            // Check if there is 1 group of 2 and return the values 
            List<int> values = new List<int>();

            foreach (Card card in cards)
            {
                values.Add((int)card.value);
            }

            values.Sort();
            values.Reverse();

            return values;
        }
    }

    public class WinningHand
    {
        public Hand whiteHand { get; }
        public Hand blackHand { get; }

        public WinningHand(Hand whiteHand, Hand blackHand)
        {
            this.whiteHand = whiteHand;
            this.blackHand = blackHand;
        }

        public static Dictionary<int, List<int>> rankHand(Hand hand)
        {

            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

            var flush = hand.isFlush();
            if (flush != null)
            {
                dic.Add(1, flush);
                return dic;
            }
            var threeOfAKind = hand.threeOfAKind();
            if (threeOfAKind != null)
            {
                dic.Add(2, threeOfAKind);
                return dic;
            }
            var twoPair = hand.twoPair();
            if (twoPair != null)
            {
                dic.Add(3, twoPair);
                return dic;
            }
            var onePair = hand.onePair();
            if (onePair != null)
            {
                dic.Add(4, onePair);
                return dic;
            }

            var highestValue = hand.highestValue();
            dic.Add(5, highestValue);
            return dic;

        }

        public String getWinningHand()
        {
            var result = rankHand(whiteHand).Keys.FirstOrDefault();
            var winningCombo = "";

            if (result == 1)
            {
                winningCombo = "flush";
            }
            if (result == 2)
            {
                winningCombo = "three of a kind";
            }
            if (result == 3)
            {
                winningCombo = "two pair";
            }
            if (result == 4)
            {
                winningCombo = "one pair";
            }

            // Winning by better hand
            if (rankHand(whiteHand).Keys.FirstOrDefault() > rankHand(blackHand).Keys.FirstOrDefault())
            {
                return $"Black hand wins by {winningCombo}";
            }
            if (rankHand(whiteHand).Keys.FirstOrDefault() < rankHand(blackHand).Keys.FirstOrDefault())
            {
                return $"White hand wins by {winningCombo}";
            }

            // Tie breaker for equal hand
            if (rankHand(whiteHand).Keys.FirstOrDefault() == rankHand(blackHand).Keys.FirstOrDefault())
            {
                // Flush
                if (result == 1)
                {
                    if (rankHand(whiteHand).Values.FirstOrDefault()[0] < rankHand(blackHand).Values.FirstOrDefault()[0])
                    {
                        return "Black hand wins by higher flush";
                    }
                    if (rankHand(whiteHand).Values.FirstOrDefault()[0] > rankHand(blackHand).Values.FirstOrDefault()[0])
                    {
                        return "White hand wins by higher flush";
                    }
                }

                // One pair
                if (result == 4)
                {
                    if (rankHand(whiteHand).Values.FirstOrDefault()[0] < rankHand(blackHand).Values.FirstOrDefault()[0])
                    {
                        return "Black hand wins by higher pair";
                    }
                    if (rankHand(whiteHand).Values.FirstOrDefault()[0] > rankHand(blackHand).Values.FirstOrDefault()[0])
                    {
                        return "White hand wins by higher pair";
                    }
                    if (rankHand(whiteHand).Values.FirstOrDefault()[0] == rankHand(blackHand).Values.FirstOrDefault()[0])
                    {
                        for (int i = 1; i < rankHand(whiteHand).Values.FirstOrDefault().Count() - 1; i++)
                        {
                            if (rankHand(whiteHand).Values.FirstOrDefault()[i] < rankHand(blackHand).Values.FirstOrDefault()[i])
                            {
                                return "Black hand wins by higher pair";
                            }
                            else
                            {
                                return "White hand wins by higher pair";
                            }
                        }
                        return "Tie by high card";
                    }
                }

                // High card
                if (result == 5)
                {
                    for (int i = 0; i < rankHand(whiteHand).Values.FirstOrDefault().Count(); i++)
                    {
                        if (rankHand(whiteHand).Values.FirstOrDefault()[i] < rankHand(blackHand).Values.FirstOrDefault()[i])
                        {
                            return "Black hand wins by high card";
                        }
                        if (rankHand(whiteHand).Values.FirstOrDefault()[i] > rankHand(blackHand).Values.FirstOrDefault()[i])
                        {
                            return "White hand wins by high card";
                        }
                    }
                }
                return "Tie";
            }
            return "Error";
        }
    }
}