using Solitaire.Model.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solitaire.Model.GameGenerators
{
    public class CombinationBasedGenerator : GameGenerator
    {
        private readonly int _columnsCount;
        private readonly int _combinationsCount;
        private readonly int _minCombinationLength;
        private readonly int _maxCombinationLength;
        private readonly float _ascendingChance;
        private readonly float _mirroringChance;

        private Random _random;

        public CombinationBasedGenerator(
            int columnsCount, 
            int combinationsCount,
            int minCombinationLength,
            int maxCombinationLength,
            float ascendingChance,
            float mirroringChance
            )
        {
            _columnsCount = columnsCount;
            _combinationsCount = combinationsCount;
            _minCombinationLength = minCombinationLength;
            _maxCombinationLength = maxCombinationLength;
            _ascendingChance = ascendingChance;
            _mirroringChance = mirroringChance;

            _random = new Random(1);
        }

        public override GameState Generate()
        {
            List<Combination> combinations = GenerateCombinations();

            Bank bank = new Bank();
            Board board = new Board(_columnsCount);

            foreach (var combination in combinations)
            {
                bank.Add(combination.First());
                foreach (var card in combination.Reverse().SkipLast(1))
                {
                    int randomColumnIndex = _random.Next(_columnsCount);
                    board.AddToColumn(card, randomColumnIndex);
                }
            }

            return GameState.CreateNewGame(bank, board);
        }

        private List<Combination> GenerateCombinations()
        {
            List<Combination> combinations = new List<Combination>(_combinationsCount);
            for (int i = 0; i < _combinationsCount; i++)
            {
                int combinationLength = _random.Next(_minCombinationLength, _maxCombinationLength + 1);
                combinations.Add(GenerateCombination(combinationLength));
            }

            return combinations;
        }

        private Combination GenerateCombination(int combinationLength)
        {
            Card card = GetRandomCard();
            bool isAscending = _random.NextDouble() < _ascendingChance;
            bool isMirrored = _random.NextDouble() < _mirroringChance;

            return new Combination(card, combinationLength, isAscending, isMirrored);
        }

        private Card GetRandomCard()
        {
            return new Card(RandomEnumValue<FaceValue>(), RandomEnumValue<Suit>());
        }

        private T RandomEnumValue<T>()
        {
            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(_random.Next(values.Length));
        }
    }
}
