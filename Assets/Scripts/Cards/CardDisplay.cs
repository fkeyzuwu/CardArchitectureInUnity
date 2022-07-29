using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private CardData data;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI manaCostText;
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI healthText;

    void Start()
    {
        InitializeCard();
    }

    public void InitializeCard()
    {
        gameObject.name = data.card.name;
        image.sprite = data.card.sprite;
        manaCostText.text = data.card.baseMana.ToString();
        attackText.text = data.card.baseAttack.ToString();
        healthText.text = data.card.baseAttack.ToString();
    }

    public void UpdateManaCostText(int manaCost)
    {
        manaCostText.text = manaCost.ToString();
    }

    public void UpdateHealthText(int health)
    {
        healthText.text = health.ToString();
    }

    public void UpdateAttackText(int attack)
    {
        attackText.text = attack.ToString();
    }
}
