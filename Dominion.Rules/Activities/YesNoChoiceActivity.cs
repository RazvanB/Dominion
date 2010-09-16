﻿namespace Dominion.Rules.Activities
{
    public abstract class YesNoChoiceActivity : ActivityBase
    {
        protected YesNoChoiceActivity(IGameLog log, Player player, string message) : 
            base(log, player, message, ActivityType.MakeYesNoChoice)
        {
        }

        public void MakeChoice(bool choice)
        {
            Execute(choice);
            IsSatisfied = true;
        }

        public abstract void Execute(bool choice);
    }

    public class WaitingForPlayersActivity : ActivityBase
    {
        public WaitingForPlayersActivity(Player waitingPlayer) 
            : base(null, waitingPlayer, "Waiting for other players...", ActivityType.WaitingForOtherPlayers)
        {
        }
    }
}