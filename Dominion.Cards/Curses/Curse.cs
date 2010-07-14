using Dominion.Rules;
using Dominion.Rules.CardTypes;

namespace Dominion.Cards.Curses
{
    public class Curse : CurseCard
    {
        public Curse() : base(0) { }

        public override int Score(DrawDeck deck)
        {
            return -1;
        }
    }
}