using UnityEngine;
using System;

[Serializable]
public abstract class Condition
{
    [HideInInspector] public string conditionName;
    [HideInInspector] public bool isMet = false;
    public BoardState startListenState = BoardState.Board; //default values
    public BoardState stopListenState = BoardState.Graveyard; //default values

    public Condition()
    {
        conditionName = this.GetType().FullName;
    }

    public abstract void AddListenForCondition();

    public abstract void RemoveListenForCondition();

    //call this when the card is supposed to start waiting for conditions. 
    //this method should subscribe OnConditionEventTrigger() to different events based on the condition.
    public abstract void OnConditionEventTrigger(EventTrigger eventTrigger);
}