using System;
using System.Linq;
using System.Collections.Generic;
using Dominion.Cards.Treasure;
using Dominion.Cards.Victory;
using Dominion.GameHost;
using Dominion.Rules;
using Dominion.Rules.CardTypes;
using TechTalk.SpecFlow;

namespace Dominion.Specs.Bindings
{
    [Binding]
    public class GameStateBindings : BindingBase
    {
        private Game _game;
        private Player _player;

        public Game Game
        {
            get { return _game; }
        }

        [Given(@"A new game with (\d+) players")]
        public void GivenANewGameWithPlayers(int playerCount)
        {            
            var startingConfig = new SimpleStartingConfiguration(playerCount);
            var names = playerCount.Items(i => "Player" + i);
            _game = startingConfig.CreateGame(names);
        }

        //[Then(@"(.*) should have (\d+) cards in hand")]
        //public void ThenPlayerShouldHaveCardsInHand(string playerName, int cardsInHand)
        //{
        //    var player = _game.Players.Where(x => x.Name == playerName).Single();
        //    player.Hand.CardCount.ShouldEqual(cardsInHand);
        //}

        [Then(@"Each player should have (\d+) cards in hand")]
        public void ThenPlayerShouldHaveCardsInHand(int cardsInHand)
        {
            foreach (var player in _game.Players)
                player.Hand.CardCount.ShouldEqual(cardsInHand);
        }

        [Then(@"The initial deck for each player should comprise of (\d+) Copper and (\d+) Estate")]
        public void ThenTheInitialDeckForEachPlayerShouldCompriseOfCopperAndEstate(int copperCount, int estateCount)
        {
            foreach (var player in _game.Players)
            {
                var coppers = player.Deck.Contents.OfType<Copper>().Count() + player.Hand.OfType<Copper>().Count();
                var estates = player.Deck.Contents.OfType<Estate>().Count() + player.Hand.OfType<Estate>().Count();

                coppers.ShouldEqual(copperCount);
                estates.ShouldEqual(estateCount);
            }
        }

        [Then(@"There should be (\d+) (.*) available to buy")]
        public void ThenThereShouldBeAvailableToBuy(int cardCount, string cardName)
        {
            _game.Bank.Piles.Single(x => x.TopCard.Name == cardName).CardCount.ShouldEqual(cardCount);
        }

        [Given(@"I am going first")]
        public void GivenIAmGoingFirst()
        {
            _player = _game.Players.First();
        }

        [When(@"I end my turn")]
        public void WhenIEndMyTurn()
        {            
            _game.CurrentTurn.EndTurn();
        }

        [Then(@"I should have (\d+) cards in the discard pile")]
        public void ThenIShouldHave5CardsInTheDiscardPile(int cardCount)
        {
            _player.Discards.CardCount.ShouldEqual(cardCount);
        }

        [Then(@"I should have (\d+) cards in hand")]
        public void ThenIShouldHave5CardsInHand(int cardCount)
        {
            _player.Hand.CardCount.ShouldEqual(cardCount);
        }

        [Then(@"(.*) is the active player")]
        public void ThenIsTheActivePlayer(string playerName)
        {
            _game.ActivePlayer.Name.ShouldEqual(playerName);
        }

        [When(@"(.*) ends their turn")]
        public void WhenPlayerEndsTheirTurn(string playerName)
        {
            _game.ActivePlayer.Name.ShouldEqual(playerName);
            _game.CurrentTurn.EndTurn();
        }

        [Given(@"I have a (.*) in hand instead of a (.*)")]
        public void GivenIHaveAInHandInsteadOfA(string cardName, string cardToReplace)
        {
            var card = CardFactory.CreateCard(cardName);
            card.MoveTo(_player.Hand);

            _player.Hand
                .First(c => c.Name == cardToReplace)
                .MoveTo(new NullZone());
        }

        //[Given(@"(\d+) action[s]? remaining")]
        //public void GivenActionRemaining(int actionCount)
        //{
        //    _game.CurrentTurn.RemainingActions = actionCount;            
        //}

        [When(@"I play (.*)")]
        public void WhenIPlay(string cardName)
        {
            var card = _player.Hand
                .OfType<ActionCard>()
                .First(c => c.Name == cardName);

            _game.CurrentTurn.Play(card);
        }

        [Then(@"I should have (\d+) actions remaining")]
        public void ThenIShouldHaveActionsRemaining(int actionCount)
        {
            _game.CurrentTurn.RemainingActions.ShouldEqual(actionCount);
        }

        [Then(@"(.*) should be in play")]
        public void ThenShouldBeInPlay(string cardName)
        {
            _game.ActivePlayer.PlayArea
                .SingleOrDefault(c => c.Name == cardName)
                .ShouldNotBeNull();
        }

        //[Given(@"I have a hand of (\d+) (.*), (\d+) (.*) and (\d+) (.*)")]
        //public void GivenIHaveAHandOf(int cardCount1, string cardName1, int cardCount2, string cardName2, int cardCount3, string cardName3)
        //{
        //    _player.Hand.MoveAll(new NullZone());

        //    var cards = new List<Card>();
        //    cards.AddRange(cardCount1.Items(() => CardFactory.CreateCard(cardName1)));
        //    cards.AddRange(cardCount2.Items(() => CardFactory.CreateCard(cardName2)));
        //    cards.AddRange(cardCount3.Items(() => CardFactory.CreateCard(cardName3)));

        //    foreach (var card in cards)
        //        card.MoveTo(_player.Hand);
        //}

        [Given(@"I have a hand of all (.*)")]
        public void GivenIHaveAHandOf(string cardName)
        {
            _player.Hand.MoveAll(new NullZone());

            var cards = 5.Items(() => CardFactory.CreateCard(cardName)).ToList();            

            foreach (var card in cards)
                card.MoveTo(_player.Hand);
        }

        [Then(@"I should have (\d+) buys")]
        public void ThenIShouldHaveBuys(int buyCount)
        {
            _game.CurrentTurn.Buys.ShouldEqual(buyCount);
        }

        [Then(@"I should have (\d+) to spend")]
        public void ThenIShouldHaveToSpend(int moneyCount)
        {
            _game.CurrentTurn.MoneyToSpend.ShouldEqual(moneyCount);
        }

        [Then(@"I should have (\d+) remaining action[s]?")]
        public void ThenIShouldHaveRemainingActions(int remainingActions)
        {
            _game.CurrentTurn.RemainingActions.ShouldEqual(remainingActions);
        }

        [Then(@"I should be in my buy step")]
        public void ThenIShouldBeInMyBuyStep()
        {
            _game.CurrentTurn.InBuyStep.ShouldBeTrue();
        }

        [Given(@"There is only (\d+) (.*) left")]
        public void GivenThereIsOnlyLeft(int cardCount, string cardName)
        {
            var pile = _game.Bank.Piles.Single(c => c.TopCard.Name == cardName);
            
            if(!pile.IsLimited)
                throw new InvalidOperationException("Cannot set the number of cards on an unlimited pile.");

            while(pile.CardCount > cardCount)
                pile.TopCard.MoveTo(new NullZone());
        }

        [Then(@"The game should have ended")]
        public void ThenTheGameShouldHaveEnded()
        {
            _game.IsComplete.ShouldBeTrue();
        }

        [When(@"(.*) ends his turn")]
        public void WhenEndsHisTurn(string playerName)
        {
            if(_game.ActivePlayer.Name != playerName)
                throw new InvalidOperationException(string.Format("{0} cannot end their turn because it is currently {1}'s turn.", playerName, _game.ActivePlayer.Name));

            _game.CurrentTurn.EndTurn();
        }

        [Then(@"The game log should report that (.*)'s turn has begun")]
        public void ThenTheGameLogShouldReportThatTurnHasBegun(string playerName)
        {
            _game.Log.Contents.ShouldContain(playerName + "'s turn has begun.");
        }

        [When(@"(.*) moves to the buy step")]
        public void WhenMovesToTheBuyStep(string playerName)
        {
            if (_game.ActivePlayer.Name != playerName)
                throw new InvalidOperationException(string.Format("{0} cannot move to the buy step because it is currently {1}'s turn.", playerName, _game.ActivePlayer.Name));
            
            _game.CurrentTurn.MoveToBuyStep();
        }

        [When(@"(.*) buys a (.*)")]
        public void WhenBuysA(string playerName, string cardName)
        {
            if (_game.ActivePlayer.Name != playerName)
                throw new InvalidOperationException(string.Format("{0} cannot buy a {1} because it is currently {2}'s turn.", playerName, cardName, _game.ActivePlayer.Name));

            var pile = _game.Bank.Piles.Single(c => c.TopCard.Name == cardName);

            _game.CurrentTurn.Buy(pile);
        }

        [Then(@"The game log should report that (.*) bought a (.*)")]
        public void ThenTheGameLogShouldReportThatBoughtA(string playerName, string cardName)
        {
            _game.Log.Contents.ShouldContain(playerName + " bought a " + cardName);
        }

        [Given(@"(.*) has a (.*) in hand instead of a (.*)")]
        public void GivenHasAInHandInsteadOfA(string playerName, string cardName, string cardToReplace)
        {
            var player = _game.Players.Single(p => p.Name == playerName);

            var card = CardFactory.CreateCard(cardName);
            card.MoveTo(player.Hand);

            player.Hand
                .First(c => c.Name == cardToReplace)
                .MoveTo(new NullZone());
        }

        [When(@"(.*) plays a (.*)")]
        public void WhenPlaysA(string playerName, string cardName)
        {
            if (_game.ActivePlayer.Name != playerName)
                throw new InvalidOperationException(string.Format("{0} cannot play a {1} because it is currently {2}'s turn.", playerName, cardName, _game.ActivePlayer.Name));

            var card = _game.ActivePlayer.Hand
                .OfType<ActionCard>()
                .First(c => c.Name == cardName);

            _game.CurrentTurn.Play(card);
        }

        [Then(@"The game log should report that (.*) played a (.*)")]
        public void ThenTheGameLogShouldReportThatPlayedA(string playerName, string cardName)
        {
            _game.Log.Contents.ShouldContain(playerName + " played a " + cardName);
        }

        [Then(@"Player (.*?) should have (\d+) card[s]? in hand")]
        public void PlayerShouldHaveNumberOfCardsInHand(string playerName, int numberOfCards)
        {
            var player = _game.Players.Single(c => c.Name.Equals(playerName, StringComparison.InvariantCultureIgnoreCase));
            player.Hand.Count().ShouldEqual(numberOfCards);
        }

        [Then(@"Player (.*?) should have a (.*?) card on top of the discard pile")]
        public void PlayerShouldHaveCardOnTopOfDiscardPile(string playerName, string cardName)
        {
            var player = _game.Players.Single(c => c.Name.Equals(playerName, StringComparison.InvariantCultureIgnoreCase));
            var cardType = _game.Bank.Piles.Single(x => x.Name.Equals(cardName, StringComparison.InvariantCultureIgnoreCase)).TopCard.GetType();
            player.Discards.TopCard.GetType().ShouldEqual(cardType);
        }
    }
}