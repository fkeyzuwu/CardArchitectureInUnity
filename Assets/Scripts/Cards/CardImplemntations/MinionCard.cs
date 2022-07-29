using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionCard : BaseCard
{
    public Tribe tribe = Tribe.None;
    public override void InitiallizeCard(Card card)
    {
        base.InitiallizeCard(card);
    }

    [ContextMenu("PlayCard")]
    public void PlayCard()
    {
        EventTrigger playMinionEvent = new OnMinionPlayedEvent() { minion = this };
        EventManager.Instance.InvokePrepareEvent(playMinionEvent);
        //^if something stops the card from being played this turn the method should terminate here.
        //in game this should be using something like async await to wait for the server response for if the action goes through.
        EventManager.Instance.InvokePerformEvent(playMinionEvent);

        foreach(CardEffect effect in effects)
        {
            foreach(Condition condition in effect.activationConditions)
            {
                condition.ListenForCondition();
            }
        }
    }

    [ContextMenu("KillCard")]
    public void KillCard()
    {
        EventTrigger diedMinionEvent = new OnMinionDiedEvent() { minion = this };
        EventManager.Instance.InvokePrepareEvent(diedMinionEvent);
        EventManager.Instance.InvokePerformEvent(diedMinionEvent);
    }
}
