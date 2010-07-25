using System;

namespace Dominion.Rules
{
    public delegate void CardZoneChanger(CardZone targetZone);

    public abstract class Card
    {
        private CardZone _currentZone;
        private readonly CardZoneChanger _zoneChanger;

        protected Card(int cost)
        {
            Cost = cost;
            _currentZone = new NullZone();
            _zoneChanger = zone => _currentZone = zone;            
        }

        public void MoveTo(CardZone targetZone)
        {
            _currentZone.MoveCard(this, targetZone, _zoneChanger);            
        }

        public CardZone CurrentZone
        {
            get { return _currentZone; }
        }

        public int Cost { get; protected set; }

        public virtual int Score(CardZone allCards)
        {
            return 0;
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}