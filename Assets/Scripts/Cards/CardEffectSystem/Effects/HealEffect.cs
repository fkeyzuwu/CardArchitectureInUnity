using System;

[Serializable]
public class HealEffect : CardEffect
{
    public int healAmount;

    public override void Activate(params ICardEffectArgument[] args)
    {
        //in the args get the card that needs to be healed
    }
}
