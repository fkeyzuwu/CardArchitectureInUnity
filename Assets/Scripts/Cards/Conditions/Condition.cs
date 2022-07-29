using UnityEngine;
using System;

[Serializable]
public abstract class Condition
{
    [HideInInspector] public string conditionName;
    [HideInInspector] public bool isMet = false;

    public Condition()
    {
        conditionName = this.GetType().FullName;
    }

    public abstract void ListenForCondition();
    //call this when the card is supposed to start waiting for conditions. 
    //this method should subscribe OnConditionEventTrigger() to different events based on the condition.
    public abstract void OnConditionEventTrigger(EventTrigger eventTrigger);
}