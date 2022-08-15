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
    private BoardState boardState = BoardState.Uninitialized;
    public int OwnerID { get; private set; }
    public BoardState BoardState
    {
        get { return boardState; }
        set
        {
            foreach (CardEffect effect in effects)
            {
                foreach (Condition condition in effect.activationConditions)
                {
                    if(condition.startListenState == value)
                    {
                        condition.AddListenForCondition();
                        Debug.Log($"{condition.conditionName} in {effect.effectName} of {data.name} card started listening");
                    }
                    else if(condition.stopListenState == value)
                    {
                        condition.RemoveListenForCondition();
                        Debug.Log($"{condition.conditionName} in {effect.effectName} of {data.name} card stopped listening");
                    }
                }
            }

            boardState = value;
        }
    }

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

        BoardState = BoardState.Deck;
        //also get owner id, for now hardcoded
        OwnerID = 1;
    }
}
public enum BoardState
{
    Uninitialized,
    Deck,
    Hand,
    Board,
    Graveyard
}