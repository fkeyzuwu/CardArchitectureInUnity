using System;
using UnityEngine;

[Serializable]
public class MinionOnBoardCondition : Condition
{
    public Alliance boardAlliance = Alliance.None;

    [Range(1, 7)]
    public int minionAmount = 1;

    public bool isTribeRequired = false;
    public Tribe tribe = Tribe.None;
    public override void AddListenForCondition()
    {
        EventManager.Instance.AddPerformListener(typeof(OnMinionPlayedEvent), OnConditionEventTrigger);
        EventManager.Instance.AddPerformListener(typeof(OnMinionDiedEvent), OnConditionEventTrigger);
    }

    public override void RemoveListenForCondition()
    {
        EventManager.Instance.RemovePerformListener(typeof(OnMinionPlayedEvent), OnConditionEventTrigger);
        EventManager.Instance.RemovePerformListener(typeof(OnMinionDiedEvent), OnConditionEventTrigger);
    }

    public override void OnConditionEventTrigger(EventTrigger eventTrigger)
    {
        //for hadgama: ownerID 1 is player, ownerID 2 is enemy
        //ingame will use the actual player ID from the client, like MyID variable
        if (eventTrigger is OnMinionPlayedEvent minionPlayedEvent)
        {
            OnMinionPlayedEventTrigger(minionPlayedEvent);
            Debug.Log($"condition is met : {isMet}");
            return;
        }

        if(eventTrigger is OnMinionDiedEvent minionDiedEvent)
        {
            OnMinionDiedEventTrigger(minionDiedEvent);
            Debug.Log($"condition is met : {isMet}");
            return;
        }

        Debug.Log("unknown EventTrigger reached this method.");

        //Will be called when a minion is played on board on either player/enemy/both AND when a minion is removed from the board.
        //it will be called at the end of the chain of actions that might have happened.
        //Depending on the type of alliance you decided on, you would subscribe this method to a different event. //maybe
    }

    private void OnMinionPlayedEventTrigger(OnMinionPlayedEvent minionPlayedEvent)
    {
        if (minionPlayedEvent.minion.OwnerID == 1 && (boardAlliance == Alliance.Player || boardAlliance == Alliance.All))
        {
            if(isTribeRequired && tribe == minionPlayedEvent.minion.tribe)
            {
                int currentMinionAmount = minionPlayedEvent.GetMinionCount(minionPlayedEvent.Player1MinionsOnBoard, tribe);
                isMet = currentMinionAmount >= minionAmount ? true : false; 
            }
            else
            {
                int currentMinionAmount = minionPlayedEvent.Player1MinionsOnBoard.Count;
                isMet = currentMinionAmount >= minionAmount ? true : false;
            }
            return;
        }

        if (minionPlayedEvent.minion.OwnerID == 2 && (boardAlliance == Alliance.Enemy || boardAlliance == Alliance.All))
        {
            if (isTribeRequired && tribe == minionPlayedEvent.minion.tribe)
            {
                int currentMinionAmount = minionPlayedEvent.GetMinionCount(minionPlayedEvent.Player2MinionsOnBoard, tribe);
                isMet = currentMinionAmount >= minionAmount ? true : false;
            }
            else
            {
                int currentMinionAmount = minionPlayedEvent.Player2MinionsOnBoard.Count;
                isMet = currentMinionAmount >= minionAmount ? true : false;
            }
            return;
        }
    }

    private void OnMinionDiedEventTrigger(OnMinionDiedEvent minionDiedEvent)
    {
        if (minionDiedEvent.minion.OwnerID == 1 && (boardAlliance == Alliance.Player))
        {
            if (minionDiedEvent.Player1MinionsOnBoard.Count == 0)
            {
                isMet = false;
                return;
            }
        }

        if (minionDiedEvent.minion.OwnerID == 2 && (boardAlliance == Alliance.Enemy))
        {
            if (minionDiedEvent.Player2MinionsOnBoard.Count == 0)
            {
                isMet = false;
                return;
            }
        }

        if (boardAlliance == Alliance.All)
        {
            if (minionDiedEvent.Player1MinionsOnBoard.Count == 0 && minionDiedEvent.Player2MinionsOnBoard.Count == 0)
            {
                isMet = false;
                return;
            }
        }
    }
}
