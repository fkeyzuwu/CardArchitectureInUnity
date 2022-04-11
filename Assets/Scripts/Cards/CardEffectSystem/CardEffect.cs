using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class CardEffect
{
    [HideInInspector] public string effectName;
    public ActivationType activationType = ActivationType.None;
    [SerializeReference] public Target target = new Target();
    [SerializeReference] public List<Condition> activationConditions = new List<Condition>();

    public CardEffect()
    {
        this.effectName = this.GetType().FullName;
    }

    public abstract void Activate(params ICardEffectArgument[] args);

    public bool IsActivatable()
    {
        foreach(Condition condition in activationConditions)
        {
            if (!condition.isMet)
            {
                return false;
            }
        }

        return true;
    }
}