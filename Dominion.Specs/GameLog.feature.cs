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
    [NUnit.Framework.DescriptionAttribute("Game Log")]
    public partial class GameLogFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GameLog.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Game Log", "In order to know what is going on\r\nAs a Dominion player\r\nI want to be told when p" +
                    "layers do things", ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("A player begins their turn")]
        public virtual void APlayerBeginsTheirTurn()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A player begins their turn", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
testRunner.Given("A new game with 3 players");
#line 8
testRunner.Then("The game log should report that Player1\'s turn has begun");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A player plays an action")]
        public virtual void APlayerPlaysAnAction()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A player plays an action", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
testRunner.Given("A new game with 3 players");
#line 12
testRunner.And("Player1 has a Woodcutter in hand instead of a Copper");
#line 13
testRunner.When("Player1 plays a Woodcutter");
#line 14
testRunner.Then("The game log should report that Player1 played a Woodcutter");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A player buys a card")]
        public virtual void APlayerBuysACard()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A player buys a card", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
testRunner.Given("A new game with 3 players");
#line 18
testRunner.When("Player1 moves to the buy step");
#line 19
testRunner.And("Player1 buys a Copper");
#line 20
testRunner.Then("The game log should report that Player1 bought a Copper");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The game ends")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void TheGameEnds()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The game ends", new string[] {
                        "Ignore"});
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
testRunner.Given("A new game with 3 players");
#line 25
testRunner.But("There is only 1 Province left");
#line 26
testRunner.And("Player1 has a hand of all Gold");
#line 27
testRunner.When("Player1 moves to the buy step");
#line 28
testRunner.And("Player1 buys a Province");
#line 29
testRunner.And("Player1 ends their turn");
#line 30
testRunner.Then("The game log should report the scores");
#line 31
testRunner.And("Player1 should be the winner");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
