public class OnMinionPlayedEvent : OnMinionBoardEvent 
{ 
    public OnMinionPlayedEvent(MinionCard minion)
        : base(minion) { }
}