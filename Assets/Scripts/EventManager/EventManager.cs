using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    public Action<OnMinionPlayedEvent> OnMinionPlayed;
    public Action<OnMinionDiedEvent> OnMinionDied;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

public abstract class OnMinionBoardEvent : IEventTrigger
{
    public MinionCard minion;
    public List<MinionCard> Player1MinionsOnBoard
    {
        get => DataManager.Instance.player1MinionsOnBoard;
    }

    public List<MinionCard> Player2MinionsOnBoard
    {
        get => DataManager.Instance.player2MinionsOnBoard;
    }

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

public class OnMinionPlayedEvent : OnMinionBoardEvent { }

public class OnMinionDiedEvent : OnMinionBoardEvent { }