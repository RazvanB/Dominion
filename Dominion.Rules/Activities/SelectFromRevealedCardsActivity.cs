﻿namespace Dominion.Rules.Activities
{
    public interface ISelectFromRevealedCardsActivity : ISelectCardsActivity, IRevealedCardsActivity
    {
    }

    public interface IRevealedCardsActivity
    {
        RevealZone RevealedCards { get; }        
    }

    public class SelectFromRevealedCardsActivity : SelectCardsActivity, ISelectFromRevealedCardsActivity
    {
        public RevealZone RevealedCards { get; private set; }

        public SelectFromRevealedCardsActivity(IGameLog log, Player player, RevealZone revealZone, string message, ISelectionSpecification selectionSpecification)
            : base(log, player, message, selectionSpecification)
        {
            RevealedCards = revealZone;

            // HACK. I'm ignoring the activity type on the selection specification. Not sure what to do here.
            Type = ActivityType.SelectFromRevealed;
        }
    }
}