﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominion.GameHost;
using Dominion.Rules;
using Dominion.Rules.Activities;

namespace Dominion.Specs.Bindings
{
    public static class Extensions
    {
        public static int GetCountProperty(this IActivity activity)
        {
            return (int) activity.Properties["NumberOfCardsToSelect"];
        }

        public static CardCost GetCostProperty(this IActivity activity)
        {
            return (CardCost)activity.Properties["Cost"];
        }

        public static Type GetTypeRestrictionProperty(this IActivity activity)
        {
            return (Type)activity.Properties["CardsMustBeOfType"];
        }

        public static string GetTypeRestrictionProperty(this ActivityModel activity)
        {
            return (string) activity.Properties["CardsMustBeOfType"];
        }

        public static string GetCardNames(this CardViewModel[] cards)
        {
            return string.Join(", ", cards.Select(c => c.Name).ToArray());
        }
    }
}
