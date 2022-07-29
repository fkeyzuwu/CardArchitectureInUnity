using System;

[Serializable]
public class DamageEffect : CardEffect
{
    public int amount;
    //public override void Activate()
    //{
    //    //pass in args the unit that needs to be damaged, construct EventTrigger args
    //    OnDamagedEvent onDamagedEvent = new OnDamagedEvent();
    //    EventManager.Instance.InvokePerformEvent(onDamagedEvent);
    //}
}
