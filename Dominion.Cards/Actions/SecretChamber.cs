﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dominion.Rules;
using Dominion.Rules.Activities;
using Dominion.Rules.CardTypes;

namespace Dominion.Cards.Actions
{
    public class SecretChamber : Card, IActionCard, IReactionCard
    {
        public SecretChamber()
            : base(2)
        {
        }

        public void React(AttackEffect attackEffect, Player player, TurnContext currentTurn)
        {
            currentTurn.AddEffect(this, new SecretChamberReactionEffect(player));
            currentTurn.Game.Log.LogMessage("{0} revealed a Secret Chamber.", player);

        }

        public bool ContinueReactingIfOnlyReaction
        {
            get { return true; }
        }        

        public void Play(TurnContext context)
        {
            context.AddEffect(this, new SecretChamberActionEffect());
        }

        private class SecretChamberReactionEffect : CardEffectBase
        {
            private readonly Player _player;

            public SecretChamberReactionEffect(Player player)
            {
                _player = player;
            }

            public override void Resolve(TurnContext context, ICard source)
            {                
                _player.DrawCards(2);
                foreach (var activity in Activities.PutMultipleCardsFromHandOnTopOfDeck(context.Game.Log, _player, 2, source))
                    _activities.Add(activity);
            }
        }

        private class SecretChamberActionEffect : CardEffectBase
        {
            public override void Resolve(TurnContext context, ICard source)
            {
                var activity = new SelectCardsActivity(
                    context,
                    "Select any number of cards to discard, you will gain $1 per card",
                    SelectionSpecifications.SelectUpToXCards(context.ActivePlayer.Hand.CardCount), source);

                activity.AfterCardsSelected = cards =>
                {
                    context.DiscardCards(activity.Player, cards);
                    context.AvailableSpend += cards.Count();                    
                };
                
                _activities.Add(activity);
            }
        }
    }


}