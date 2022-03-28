using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Card")]
public class Card : ScriptableObject
{
    public new string name;
    public string description;
    public int health;
    public int attack;
    public int mana;

    [SerializeReference] public List<CardEffect> effects = new List<CardEffect>();
}
