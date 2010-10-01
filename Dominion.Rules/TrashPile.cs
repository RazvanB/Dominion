﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominion.Rules
{
    public class TrashPile : EnumerableCardZone
    {
        public ICard TopCard
        {
            get { return this.Cards.Last(); }
        }
    }
}
