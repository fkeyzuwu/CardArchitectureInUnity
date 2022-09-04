using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionCard : BaseCard
{
    public Tribe tribe = Tribe.None;
    public override void InitiallizeCard(Card card)
    {
        base.InitiallizeCard(card);
        BoardState = BoardState.Deck;
    }

    [ContextMenu("DrawCard")]
    public void DrawCard()
    {
        EventTrigger drawCardEvent = new OnCardDrawnEvent(this);
        //EventManager.Instance.InvokePrepareEvent(drawCardEvent);
        EventManager.Instance.InvokePerformEvent(drawCardEvent);
        BoardState = BoardState.Hand;
    }

    [ContextMenu("PlayCard")]
    public void PlayCard()
    {
        EventTrigger playMinionEvent = new OnMinionPlayedEvent(this);
        //EventManager.Instance.InvokePrepareEvent(playMinionEvent);
        //^if something stops the card from being played this turn the method should terminate here.
        //in game this should be using something like async await to wait for the server response for if the action goes through.
        EventManager.Instance.InvokePerformEvent(playMinionEvent);
        BoardState = BoardState.Board;
    }

    [ContextMenu("KillCard")]
    public void KillCard()
    {
        EventTrigger diedMinionEvent = new OnMinionDiedEvent(this);
        //EventManager.Instance.InvokePrepareEvent(diedMinionEvent);
        EventManager.Instance.InvokePerformEvent(diedMinionEvent);
        BoardState = BoardState.Graveyard;
    }
}
