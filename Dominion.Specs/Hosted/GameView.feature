﻿Feature: Game View
	In order to play Dominion
	As a Dominion player
	I need information about the game state

Scenario: Determine the types of the cards in hand
	Given A new hosted game with 3 players		
	And Player1 has a hand of GreatHall, Witch, Moat, Curse, Copper	
	When The game begins
	Then Player1's view includes a GreatHall in hand with types Action and Victory
	And Player1's view includes a Witch in hand with types Action and Attack
	And Player1's view includes a Moat in hand with types Action and Reaction
	And Player1's view includes a Curse in hand with the type Curse
	And Player1's view includes a Copper in hand with the type Treasure

Scenario: Active player can buy card in buy step
	Given A new hosted game with 3 players			
	When The game begins
	Then Player1's view includes a Copper in the bank that can be bought	

Scenario: Non active players cannot buy anything
	Given A new hosted game with 3 players			
	When The game begins	
	Then Player2's view includes nothing in the bank that can be bought
	Then Player3's view includes nothing in the bank that can be bought	

Scenario: Active player cannot buy card if in action step
	Given A new hosted game with 3 players		
	And Player1 has a Militia in hand instead of a Copper
	When The game begins
	Then Player1's view includes nothing in the bank that can be bought

Scenario: Active player can play card in action step
	Given A new hosted game with 3 players		
	And Player1 has a Militia in hand instead of a Copper
	When The game begins
	Then Player1's view includes a Militia in hand that can be played

Scenario: Non active players cannot play anything
	Given A new hosted game with 3 players			
	And Player2 has a Militia in hand instead of a Copper
	And Player3 has a Militia in hand instead of a Copper
	When The game begins	
	Then Player2's view includes nothing in hand that can be played
	Then Player3's view includes nothing in hand that can be played

Scenario: Active player cannot play card if in buy step
	Given A new hosted game with 3 players		
	And Player1 has a Militia in hand instead of a Copper
	When The game begins
	When Player1 tells the host to move to the buy step
	Then Player1's view includes nothing in hand that can be played