using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Card")]
public class Card : ScriptableObject
{
    public new string name;
    public string description;
    public CardType type;
    public int baseHealth;
    public int baseAttack;
    public int baseMana;

    [SerializeReference] public List<CardEffect> effects = new List<CardEffect>();
}