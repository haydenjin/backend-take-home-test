# Brew Ninja .NET Developer / Engineer - Take Home Test
## Comments reagrding completed code: 

Not all test cases / hand options are created (due to time constraints). Only provided sample test cases will pass. If more time allocated then code can be completed 100% / optimized further.

## Instructions

Fork this repository.  Use C# ([any supported .NET version](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core)) and object-oriented design principles to implement your solution.

- A Visual Studio solution is provided for you in the `src` folder.  It contains a class library project `PokerHand` that will contain the models and algorithms - the "production code" - and a unit test project `PokerHandTest` that will hold the automated tests that sufficiently test the class library.  **Do not add a console application or similar to manually test the algorithm**; testing is the responsibility of your automated test suite.  Your production and test code must be executable as-is without additional setup or modifications.
- You are encouraged to use [SOLID design principles](https://en.wikipedia.org/wiki/SOLID) and [domain driven design](https://en.wikipedia.org/wiki/Domain-driven_design) in your implementation.
- You are encouraged to use [`xUnit`](https://xunit.net/) and [`FluentAssertions`](https://fluentassertions.com/) to implement your test suite.  Both libraries are already installed in the `PokerHandTest` project.
- The test scenarios listed near the bottom of this document are necessary but not sufficient to ensure program correctness.  You do not need an exhaustive test suite, but your test cases must be thorough enough for you to be reasonably confident that your implementation is correct.
- Your submission will be assessed according to its [evolvability](https://smartbear.com/blog/how-code-review-reveals-software-evolvability-issu/) (i.e. how easy it is to extend your submission with new features) and [testability](https://en.wikipedia.org/wiki/Software_testability) (i.e. the quality of your automated test suite), as well as your familiarity with C# language constructs (such as LINQ).  You will be given comprehensive feedback on your solution regardless of whether or not we choose to proceed with hiring.
- Aim to spend no more than 60-90 minutes creating your solution.  We value your time!

When you have completed the challenge, notify your point of contact at Brew Ninja with a link to your fork.

## Requirements

1. A poker deck contains 52 cards.

   - Each card has a suit which is one of 4 possible values: clubs, diamonds, hearts, or spades.
   - Each card also has a value which is one of 13 possible values: `2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `10`, `jack`, `queen`, `king`, `ace`.

2. For scoring purposes, the suits are unordered while the values are ordered as listed above; `2` is lowest value, `ace` is highest value.

3. A poker hand consists of 5 cards dealt from the deck.  Hands are ranked by the following partial order from lowest to highest:

    - **HIGH CARD**...  Hands which do not fit any higher category are ranked by the value of their highest card.  If the highest cards have the same value, the hands are ranked by the next highest, and so on.
    - **PAIR**...  2 of the 5 cards in the hand have the same value.  Hands which both contain a pair are ranked by the value of the cards forming the pair.  If these values are the same, the hands are ranked by the values of the cards not forming the pair, in decreasing order.
    - **TWO PAIRS**...  The hand contains 2 different pairs.  Hands which both contain 2 pairs are ranked by the value of their highest pair.  Hands with the same highest pair are ranked by the value of their other pair.  If these values are the same the hands are ranked by the value of the remaining card.
    - **THREE OF A KIND**...  Three of the cards in the hand have the same value.  Hands which both contain three of a kind are ranked by the value of the 3 cards.
    - **FLUSH**...  Hand contains 5 cards of the same suit.  Hands which are both flushes are ranked using the rules for High Card.

4. Your task is to rank pairs of poker hands and to indicate which, if either, has a higher rank.  Examples listed below show pairs of hands dealt to the two players and the corresponding expected result.  Suits are denoted `C`, `D`, `H`, and `S`. Card values are denoted `2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `10`, `J`, `Q`, `K`, `A`.

   - `BLACK: 2H 3D 5S 9C KD  &  WHITE: 2C 3H 4S 8C AH` => `WHITE WINS... high card: Ace`
   - `BLACK: 2C 2S AH JC 4C  &  WHITE: AH AD 2H 3S 6S` => `WHITE WINS... higher pair (Ace > 2)`
   - `BLACK: 2H 4S 4C 3D 4H  &  WHITE: 2S 8S AS QS 3S` => `WHITE WINS... flush`
   - `BLACK: 3C 7C 6C JC 4C  &  WHITE: 2S 8S 4S QS 3S` => `WHITE WINS... higher flush (Queen > Jack)`
   - `BLACK: 2H 3D 5S 9C KD  &  WHITE: 2C 3H 4S 8C KH` => `BLACK WINS... high card: 9`
   - `BLACK: 2H 3D 5S 9C KD  &  WHITE: 2D 3H 5C 9S KH` => `TIE`

    Please note that the above should not be treated as console input and output.  They are merely examples for illustrative purposes.
