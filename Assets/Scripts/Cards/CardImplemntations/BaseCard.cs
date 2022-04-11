public class BaseCard
{
    public Card data;
    public string name { get => data.name; }
    public string description { get => data.description; }
    public int health;
    public int attack;
    public int mana;
    public BoardState boardState = BoardState.Uninitialized;
    public int OwnerID { get; private set; }

    public BaseCard(Card card)
    {
        data = card;
        health = data.baseHealth;
        attack = data.baseAttack;
        mana = data.baseMana;
        boardState = BoardState.Deck;
        //also get owner id
    }
}

public enum BoardState
{
    Uninitialized,
    Deck,
    Board,
    Graveyard
}