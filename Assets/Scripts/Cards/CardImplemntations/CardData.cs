using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public Card card;

    void Start()
    {
        if(card.type == CardType.Minion)
        {
            gameObject.AddComponent<MinionCard>().InitiallizeCard(card);
        }
        else if(card.type == CardType.Spell)
        {
            gameObject.AddComponent<SpellCard>().InitiallizeCard(card);
        }
    }
}
