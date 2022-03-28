using System;
using UnityEngine;

[Serializable]
public class MinionOnBoardCondition : Condition
{
    public Alliance boardAlliance = Alliance.None;
    public override void ListenForCondition()
    {
        EventManager.Instance.OnMinionPlayed += OnConditionEventTrigger;
        EventManager.Instance.OnMinionDied += OnConditionEventTrigger;
    }

    public override void OnConditionEventTrigger(IEventTrigger eventTrigger)
    {
        //for hadgama: ownerID 1 is player, ownerID 2 is enemy
        //ingame will use the actual player ID from the client, like MyID variable
        if (eventTrigger is OnMinionPlayedEvent minionPlayedEvent)
        {
            if (minionPlayedEvent.minionPlayed.OwnerID == 1 && (boardAlliance == Alliance.Player || boardAlliance == Alliance.All))
            {
                if (!isMet) isMet = true;
                return;
            }
            
            if (minionPlayedEvent.minionPlayed.OwnerID == 2 && (boardAlliance == Alliance.Enemy || boardAlliance == Alliance.All))
            {
                if (!isMet) isMet = true;
                return;
            }
        }

        if(eventTrigger is OnMinionDiedEvent minionDiedEvent)
        {
            if (minionDiedEvent.minionDied.OwnerID == 1 && (boardAlliance == Alliance.Player))
            {
                if (minionDiedEvent.Player1MinionsOnBoard == 0)
                {
                    isMet = false;
                    return;
                }
            }

            if (minionDiedEvent.minionDied.OwnerID == 2 && (boardAlliance == Alliance.Enemy))
            {
                if (minionDiedEvent.Player2MinionsOnBoard == 0)
                {
                    isMet = false;
                    return;
                }
            }

            if(boardAlliance == Alliance.All)
            {
                if (minionDiedEvent.Player1MinionsOnBoard == 0 && minionDiedEvent.Player2MinionsOnBoard == 0)
                {
                    isMet = false;
                    return;
                }
            }
        }

        Debug.Log("unknown EventTrigger reached this method.");

        //Will be called when a minion is played on board on either player/enemy/both AND when a minion is removed from the board.
        //it will be called at the end of the chain of actions that might have happened.
        //Depending on the type of alliance you decided on, you would subscribe this method to a different event. //maybe
    }
}
