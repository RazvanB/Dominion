﻿Feature: Throne Room

Background:
	Given A new game with 3 players		

Scenario: Player must choose which card to use Throne Room's effect on
	Given Player1 has a ThroneRoom in hand instead of a Copper		
	Given Player1 has a Smithy in hand instead of a Copper	
	When Player1 plays a ThroneRoom
	Then Player1 must select 1 action card

Scenario: Player uses Throne Room's effect on a Smithy
	Given Player1 has a ThroneRoom in hand instead of a Copper		
	Given Player1 has a Smithy in hand instead of a Copper	
	When Player1 plays a ThroneRoom
	When Player1 selects a Smithy to ThroneRoom
	Then Player1 should have 8 cards in hand	

Scenario: Player plays Throne Room with no action cards in hand
	Given Player1 has a ThroneRoom in hand instead of a Copper		
	When Player1 plays a ThroneRoom
	Then All actions should be resolved

Scenario: Player uses Throne Room's effect on a Throne Room 
	Given Player1 has a hand of ThroneRoom, ThroneRoom, Smithy, Chancellor, Copper	
	When Player1 plays a ThroneRoom
	When Player1 selects a ThroneRoom to ThroneRoom	
	When Player1 selects a Chancellor to ThroneRoom
	When Player1 chooses No	
	When Player1 chooses No
	When Player1 selects a Smithy to ThroneRoom
	Then Player1 should have 6 cards in hand	
	And Player1 should have 4 to spend	