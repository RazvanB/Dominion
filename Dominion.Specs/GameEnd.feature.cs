// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.3.5.2
//      Runtime Version:4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace Dominion.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.5.2")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Game End")]
    public partial class GameEndFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GameEnd.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Game End", "In order to avoid playing Dominion forever\r\nAs a Dominion player\r\nI want the game" +
                    " to end at some point", ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Game ends when last province is bought")]
        public virtual void GameEndsWhenLastProvinceIsBought()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Game ends when last province is bought", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
testRunner.Given("A new game with 3 players");
#line 8
testRunner.But("There is only 1 Province left");
#line 9
testRunner.And("Player1 has 5 Gold in hand");
#line 10
testRunner.When("Player1 moves to the buy step");
#line 11
testRunner.And("Player1 buys a Province");
#line 12
testRunner.And("Player1 ends their turn");
#line 13
testRunner.Then("The game should have ended");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void GameEndsWhenPilesAreExhausted(string playerCount, string emptyPileCount)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Game ends when piles are exhausted", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
testRunner.Given(string.Format("A new game with {0} players", playerCount));
#line 17
testRunner.And(string.Format("There are {0} empty piles", emptyPileCount));
#line 18
testRunner.When("Player1 ends their turn");
#line 19
testRunner.Then("The game should have ended");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Game ends when piles are exhausted")]
        public virtual void GameEndsWhenPilesAreExhausted_1()
        {
            this.GameEndsWhenPilesAreExhausted("1", "3");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Game ends when piles are exhausted")]
        public virtual void GameEndsWhenPilesAreExhausted_2()
        {
            this.GameEndsWhenPilesAreExhausted("2", "3");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Game ends when piles are exhausted")]
        public virtual void GameEndsWhenPilesAreExhausted_3()
        {
            this.GameEndsWhenPilesAreExhausted("3", "3");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Game ends when piles are exhausted")]
        public virtual void GameEndsWhenPilesAreExhausted_4()
        {
            this.GameEndsWhenPilesAreExhausted("4", "3");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Game ends when piles are exhausted")]
        public virtual void GameEndsWhenPilesAreExhausted_5()
        {
            this.GameEndsWhenPilesAreExhausted("5", "4");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Game ends when piles are exhausted")]
        public virtual void GameEndsWhenPilesAreExhausted_6()
        {
            this.GameEndsWhenPilesAreExhausted("6", "4");
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Game still ends when more piles are exhausted than necessary")]
        public virtual void GameStillEndsWhenMorePilesAreExhaustedThanNecessary()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Game still ends when more piles are exhausted than necessary", ((string[])(null)));
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
testRunner.Given("A new game with 4 players");
#line 32
testRunner.And("There are 4 empty piles");
#line 33
testRunner.When("Player1 ends their turn");
#line 34
testRunner.Then("The game should have ended");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Game isn\'t over until the last turn ends")]
        public virtual void GameIsnTOverUntilTheLastTurnEnds()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Game isn\'t over until the last turn ends", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line 37
testRunner.Given("A new game with 3 players");
#line 38
testRunner.But("There is only 1 Province left");
#line 39
testRunner.And("Player1 has 5 Gold in hand");
#line 40
testRunner.When("Player1 moves to the buy step");
#line 41
testRunner.And("Player1 buys a Province");
#line 42
testRunner.Then("The game should not have ended");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
