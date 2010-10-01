﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominion.Rules
{
    public class DrawDeck : CardZone
    {
        private readonly DiscardPile _discards;

        public DrawDeck(IEnumerable<ICard> startingCards, DiscardPile discards)
        {
            foreach (Card card in startingCards)
                card.MoveTo(this);

            _discards = discards;
        }

        public virtual void Shuffle()
        {
            RandomizeOrder();
        }

        public ICard TopCard
        {
            get
            {
                if (CardCount == 0)
                {
                    _discards.MoveAll(this);
                    Shuffle();
                }

                return this.Cards.FirstOrDefault();
            }
        }

        public void MoveCards(CardZone cardZone, int count)
        {
            count.Times(() => TopCard.MoveTo(cardZone));
        }

        public IEnumerable<ICard> Contents
        {
            get { return this.Cards; }
        }

        public void MoveToTop(ICard card)
        {
            card.MoveTo(this);
            this.Cards.Remove(card);
            this.Cards.Insert(0, card);
        }

        public void MoveTop(int count, CardZone cardZone)
        {
            count.Times(() =>
            {
                if (TopCard != null) 
                    TopCard.MoveTo(cardZone);
            });                       
        }
    }
}