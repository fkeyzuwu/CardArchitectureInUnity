using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;

[Serializable]
public abstract class CardEffect
{
    [HideInInspector] public string effectName;
    public ActivationType activationType = ActivationType.None;
    [SerializeReference] public Target target = new Target();
    [SerializeReference] public List<Condition> activationConditions = new List<Condition>();

    [HideInInspector] public BaseCard parent;

    public CardEffect()
    {
        this.effectName = this.GetType().FullName;
    }

    //whenever the card effect is activateable and needs to be activated, run this.
    //then at run time get the targets for the effect. if isTargeted, you can run a code inside to delay it by some time, like using courotine on a different method.
    public virtual void Activate()
    {
        if (IsActivatable())
        {
            parent.StartCoroutine(ExecuteEffect());
            //play animations here?
        }
    }

    private IEnumerator ExecuteEffect()
    {
        Debug.Log($"Effect {effectName} has been activated");
        yield return null;

        //if (target.isTargeted)
        //{
        //    yield return parent.StartCoroutine(GetPlayerInput());
        //}

        //yield return parent.StartCoroutine(PlayPrepareAnimation());
        //yield return parent.StartCoroutine(PlayPerformAnimation());
    }

    private IEnumerator GetPlayerInput()
    {
        float waitTime = Time.deltaTime;

        while(target.selected == null)
        {
            //wait for player to select a card target
            yield return new WaitForSeconds(waitTime);
        }
    }

    //have the card effect automatically use the animation from a generic card field.
    //wait for the keyframe for the card effect to actually go through, and only then let go of the coroutine and do the effect(maybe?).
    private IEnumerator PlayPrepareAnimation()
    {
        yield return null;
    }

    private IEnumerator PlayPerformAnimation()
    {
        yield return null;
    }

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