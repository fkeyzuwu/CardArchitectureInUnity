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

public class OnMinionPlayedEvent : IEventTrigger
{
    public Minion minionPlayed;
    public int Player1MinionsOnBoard
    {
        get => DataManager.Instance.player1MinionsOnBoard;
    }

    public int Player2MinionsOnBoard
    {
        get => DataManager.Instance.player2MinionsOnBoard;
    }
}

public class OnMinionDiedEvent : IEventTrigger
{
    public Minion minionDied;
    public int Player1MinionsOnBoard
    {
        get => DataManager.Instance.player1MinionsOnBoard;
    }

    public int Player2MinionsOnBoard
    {
        get => DataManager.Instance.player2MinionsOnBoard;
    }
}