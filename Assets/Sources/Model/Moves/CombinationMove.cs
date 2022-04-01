using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Sources.Model
{
    public class CombinationMove : IMove
    {
        public CombinationMove(Card card)
        {
            Card = card;
        }

        public Card Card { get; private set; }
    }
}
