﻿using Dominion.Rules;
using Dominion.Rules.Activities;
using Dominion.Rules.CardTypes;

namespace Dominion.Cards.Actions
{
    public class Feast : Card, IActionCard
    {
        public Feast() : base(4) { }

        public void Play(TurnContext context)
        {
            context.Trash(context.ActivePlayer, this);
            context.AddEffect(new FeastEffect(context));
        }
    }

    public class FeastEffect : CardEffectBase
    {
        public FeastEffect(TurnContext context)
        {
            _activities.Add(new GainACardUpToActivity(context.Game.Log, context.ActivePlayer, 5));
        }
    }
}
