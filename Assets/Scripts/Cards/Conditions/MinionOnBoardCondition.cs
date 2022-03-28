using System;

[Serializable]
public class MinionOnBoardCondition : Condition
{
    public override void ListenForCondition()
    {
        
    }

    public override void OnConditionEventTrigger(IEventTrigger eventTrigger)
    {
        //Will be called when a minion is played on board on either player/enemy/both AND when a minion is removed from the board.
        //it will be called at the end of the chain of actions that might have happened.
        //Depending on the type of alliance you decided on, you would subscribe this method to a different event. //maybe

        /* Example:
            if(eventTrigger is MinionPlayedOnBoardEvent minionPlayed)
            {
                if(minionPlayed.playerMinion)
                {
                    if (!isMet) isMet = true;
                    return;
                }
            }
            
            if(eventTrigger is MinionDiedOnBoardEvent minionDied)
            {
                if(minionDied.playerMinion)
                {
                    if(minionDied.currentMinionsOnPlayerBoard == 0)
                    {
                        isMet = false;
                        return;
                    }
                }
            }
            
            Debug.Log("unknown EventTrigger reached this method");
        */
    }
}
