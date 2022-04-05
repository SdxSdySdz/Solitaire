using Solitaire.Model.GameLogic;

namespace Solitaire.Model.GameGenerators
{
    public abstract class GameGenerator
    {
        public abstract GameState Generate();
    }
}
