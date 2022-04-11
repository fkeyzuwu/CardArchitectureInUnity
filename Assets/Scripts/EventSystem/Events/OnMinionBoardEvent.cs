using System.Collections.Generic;

public abstract class OnMinionBoardEvent : EventTrigger
{
    public MinionCard minion;
    public List<MinionCard> Player1MinionsOnBoard { get => DataManager.Instance.player1MinionsOnBoard;}
    public List<MinionCard> Player2MinionsOnBoard { get => DataManager.Instance.player2MinionsOnBoard; }

    public int GetMinionCount(List<MinionCard> minions, Tribe tribe)
    {
        int minionCount = 0;

        foreach (MinionCard minion in minions)
        {
            if (minion.tribe == tribe)
            {
                minionCount++;
            }
        }

        return minionCount;
    }

    public int GetMinionCount(List<MinionCard> minions)
    {
        return minions.Count;
    }
}
