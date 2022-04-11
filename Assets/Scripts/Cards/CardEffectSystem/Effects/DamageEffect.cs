using System;

[Serializable]
public class DamageEffect : CardEffect
{
    public int damageAmount;

    public override void Activate(params ICardEffectArgument[] args)
    {
        //pass in args the unit that needs to be damaged, construct EventTrigger args
        OnDamagedEvent onDamagedEvent = new OnDamagedEvent();
        EventManager.Instance.InvokePerformEvent(onDamagedEvent);
    }
}
