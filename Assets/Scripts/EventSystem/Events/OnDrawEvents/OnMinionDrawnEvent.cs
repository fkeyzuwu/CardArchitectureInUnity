public class OnMinionDrawnEvent : OnCardDrawnEvent
{
    public OnMinionDrawnEvent(MinionCard card)
        : base(card) { }

    public MinionCard minion
    {
        get 
        {
            return (MinionCard)base.card;
        }
    }
}
