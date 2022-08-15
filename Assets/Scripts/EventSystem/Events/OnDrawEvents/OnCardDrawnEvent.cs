public class OnCardDrawnEvent : EventTrigger
{
    public BaseCard card;

    public OnCardDrawnEvent(BaseCard card)
    {
        this.card = card;
    }
}
