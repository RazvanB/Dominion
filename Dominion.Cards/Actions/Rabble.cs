﻿using System;
using System.Linq;
using Dominion.Rules;
using Dominion.Rules.Activities;
using Dominion.Rules.CardTypes;

namespace Dominion.Cards.Actions
{
    public class Rabble : Card, IActionCard, IAttackCard
    {
        public Rabble()
            : base(5)
        {
        }

        public void Play(TurnContext context)
        {
            context.DrawCards(3);
            context.AddEffect(this, new RabbleAttack());
        }

        private class RabbleAttack : AttackEffect
        {
            public override void Attack(Player victim, TurnContext context, ICard source)
            {
                var revealZone = new RevealZone(victim);
                victim.Deck.MoveTop(3, revealZone);

                revealZone.LogReveal(context.Game.Log);
                revealZone.MoveWhere(c => c is IActionCard || c is ITreasureCard, victim.Discards);

                foreach (var activity in Activities.SelectMultipleRevealedCardsToPutOnTopOfDeck(context.Game.Log, victim, revealZone, source))
                    _activities.Add(activity);
            }

        }
    }
}