using System.Collections.Generic;
using UnityEngine;

public class BaseCard : MonoBehaviour
{
    public Card data;
    public new string name { get => data.name; }
    public string description { get => data.description; }
    public int health;
    public int attack;
    public int mana;
    public List<CardEffect> effects;
    public BoardState boardState = BoardState.Uninitialized;
    public int OwnerID { get; private set; }

    public virtual void InitiallizeCard(Card card)
    {
        data = card;

        health = data.baseHealth;
        attack = data.baseAttack;
        mana = data.baseMana;

        effects = data.effects;
        foreach (CardEffect effect in effects)
        {
            effect.parent = this;
        }

        boardState = BoardState.Deck;
        //also get owner id, for now hardcoded
        OwnerID = 1;
    }
}
public enum BoardState
{
    Uninitialized,
    Deck,
    Board,
    Graveyard
}