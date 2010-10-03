using System;

namespace Dominion.Rules
{
    public delegate void CardZoneChanger(CardZone targetZone);

    public abstract class Card : Dominion.Rules.ICard
    {
        private CardZone _currentZone;
        private readonly CardZoneChanger _zoneChanger;

        public Guid Id { get; private set; }
        
        protected Card(CardCost cost)
        {
            Id = Guid.NewGuid();
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

        public CardCost Cost { get; protected set; }


        public string Name
        {
            get { return this.GetType().Name; }
        }        

        public override string ToString()
        {
            return this.Name;
        }
    }
}