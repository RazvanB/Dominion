using System;
using Dominion.Rules;
using Dominion.Rules.Activities;
using Dominion.Rules.CardTypes;

namespace Dominion.Cards.Actions
{
    public class Chancellor : ActionCard
    {
        public Chancellor() : base(3)
        {
        }

        protected override void Play(TurnContext context)
        {
            context.MoneyToSpend += 2;
            context.AddEffect(new ChancellorEffect(context));
        }

        public class ChancellorEffect : CardEffectBase
        {
            public ChancellorEffect(TurnContext context)
            {
                _activities.Add(new ChancellorActivity(context.Game.Log, context.ActivePlayer, "Do you wish to put your deck into your discard pile?"));
            }

            public class ChancellorActivity : YesNoChoiceActivity
            {
                public ChancellorActivity(IGameLog log, Player player, string message)
                    : base(log, player, message)
                {
                }

                public override void Execute(bool choice)
                {
                    if (choice)
                    {
                        Log.LogMessage("{0} put his deck in his discard pile", Player.Name);
                        this.Player.Deck.MoveAll(this.Player.Discards);
                    }
                }
            }
        }
    }
}