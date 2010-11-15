﻿Feature: Salvager

Background:
	Given A new game with 3 players	

Scenario: Salvager trashes a card
	And Player1 has a Salvager in hand instead of a Copper
	When Player1 plays a Salvager
	Then Player1 must select 1 card to trash

Scenario: Salvager trashing estate gives plus 2 spend
	And Player1 has a Salvager in hand instead of a Copper
	When Player1 plays a Salvager
	And Player1 selects a Estate to trash
	Then Player1 should have 2 to spend
	And There should be a Estate on top of the trash pile	

Scenario: Salvager gives plus one buy
	And Player1 has a Salvager in hand instead of a Copper
	When Player1 plays a Salvager
	Then Player1 should have 2 buys

Scenatio: Salvager with no other cards in hand
	And Player1 has a hand of Salvager
	When Player1 plays a Salvager
	Then the trash pile should be empty
	And Player1 should have 2 buys

