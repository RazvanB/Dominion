﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dominion.Rules.Activities;

namespace Dominion.GameHost.AI.BehaviourBased
{
    public abstract class SelectFixedNumberOfCardsBehaviourBase : IAIBehaviour
    {
        public virtual bool CanRespond(ActivityModel activity, GameViewModel state)
        {
            return activity.ParseType() == ActivityType.SelectFixedNumberOfCards;
        }

        protected abstract IEnumerable<CardViewModel> PrioritiseCards(GameViewModel state);

        public void Respond(IGameClient client, ActivityModel activity, GameViewModel state)
        {
            int count = activity.ParseNumberOfCardsToSelect();

            var ids = PrioritiseCards(state)
                .Take(count)
                .Select(c => c.Id)
                .ToArray();
            
            var message = new SelectCardsMessage(client.PlayerId, ids);
            client.AcceptMessage(message);
        }
    }
}