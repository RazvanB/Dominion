﻿using System;
using Dominion.Rules;
using Dominion.Rules.Activities;
using Dominion.Rules.CardTypes;

namespace Dominion.Cards.Actions
{
    public class Workshop : Card, IActionCard
    {
        public Workshop() : base(3)
        {
        }

        public void Play(TurnContext context)
        {
            context.AddEffect(this, new WorkshopEffect());
        }

        public class WorkshopEffect : CardEffectBase
        {
            public override void Resolve(TurnContext context, ICard source)
            {
                _activities.Add(Activities.GainACardCostingUpToX(context.Game.Log, context.ActivePlayer, 4, source));

            }
        }
    }
}