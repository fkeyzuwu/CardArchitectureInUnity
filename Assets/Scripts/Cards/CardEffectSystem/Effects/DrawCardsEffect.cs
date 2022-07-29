using System;
using System.Collections.Generic;

[Serializable]
public class DrawCardsEffect : CardEffect
{
    public int amount;
    public List<BaseCard> cards;
}
