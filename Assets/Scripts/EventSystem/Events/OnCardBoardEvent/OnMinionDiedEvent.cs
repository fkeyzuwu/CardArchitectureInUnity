public class OnMinionDiedEvent : OnMinionBoardEvent 
{
    public OnMinionDiedEvent(MinionCard minion)
        : base(minion) { }
}