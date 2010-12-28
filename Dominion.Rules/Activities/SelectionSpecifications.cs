﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominion.Rules.Activities
{

    public interface ISelectionSpecification
    {
        bool IsMatch(CardPile pile);
        bool IsMatch(IEnumerable<ICard> cards);
        ActivityType ActivityType { get; set; }
        Type CardTypeRestriction { get; set; }
        void WriteProperties(IDictionary<string, object> bag);        
    }

    public static class SelectionSpecifications
    {
        public static ISelectionSpecification SelectExactlyXCards(int cardCount)
        {
            return new SelectionSpecification
            {
                MatchFunction = cards => cards.Count() == cardCount,
                ActivityType = ActivityType.SelectFixedNumberOfCards,
                Count = cardCount
            };
        }

        public static ISelectionSpecification SelectUpToXCards(int countUpTo)
        {
            return new SelectionSpecification
            {
                MatchFunction = cards => cards.Count() <= countUpTo,
                ActivityType = ActivityType.SelectUpToNumberOfCards,
                Count = countUpTo
            };
        }

        public static ISelectionSpecification SelectPileCostingUpToX(CardCost costUpTo)
        {
            return new SelectionSpecification
            {
                MatchFunction = cards => cards.Count() == 1 && costUpTo.IsEnoughFor(cards.Single()),
                ActivityType = ActivityType.SelectPile,
                Cost = costUpTo
            };
        }

        public static ISelectionSpecification SelectPileCostingExactlyX(CardCost cost)
        {
            return new SelectionSpecification
            {
                MatchFunction = cards => cards.Count() == 1 && cost == cards.Single().Cost,
                ActivityType = ActivityType.SelectPile,
                Cost = cost
            };
        }

        public static ISelectionSpecification SelectUpToXCardsOfSameName(string name, int countUpTo)
        {
            return new SelectionSpecification
            {                
                ActivityType = ActivityType.SelectUpToNumberOfCards,
                CardNameRestriction = name,
                Count = countUpTo
            };
        }

        private class SelectionSpecification : ISelectionSpecification
        {            
            public Func<IEnumerable<ICard>, bool> MatchFunction { get; set; }
            public ActivityType ActivityType { get; set; }
            public Type CardTypeRestriction { get; set; }
            public string CardNameRestriction { get; set; }
            public int? Count { get; set; }
            public CardCost Cost { get; set; }

            public void WriteProperties(IDictionary<string, object> bag)
            {
                if (Cost != null)
                    bag["Cost"] = Cost;

                if(Count != null)
                    bag["NumberOfCardsToSelect"] = Count;

                if (CardTypeRestriction != null)
                    bag["CardsMustBeOfType"] = this.CardTypeRestriction.Name;

                if (CardNameRestriction != null)
                    bag["CardMustHaveName"] = this.CardNameRestriction;
            }

            public bool IsMatch(CardPile pile)
            {
                if (pile.IsEmpty)
                    return false;

                return IsMatch(new[] {pile.TopCard});
            }

            public bool IsMatch(IEnumerable<ICard> cards)
            {
                if (CardTypeRestriction != null && 
                    cards.All(c => c.GetType().GetInterfaces().Contains(CardTypeRestriction)) == false)
                    return false;

                if (CardNameRestriction != null &&
                    cards.All(c => c.Name == CardNameRestriction) == false)
                    return false;

                if(MatchFunction != null)
                    return MatchFunction(cards);

                return true;
            }           
        }
    }
}