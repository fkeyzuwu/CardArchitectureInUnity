using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionCard : BaseCard
{
    public Tribe tribe = Tribe.None;
    public MinionCard(Card card) : base(card)
    {

    }
}
