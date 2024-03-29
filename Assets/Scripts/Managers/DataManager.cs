﻿using UnityEngine;
using System;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public List<MinionCard> player1MinionsOnBoard = new List<MinionCard>();
    public List<MinionCard> player2MinionsOnBoard = new List<MinionCard>();
    void Start()
    {
        #region Singleton

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        #endregion

        EventManager.Instance.AddPerformListener(typeof(OnMinionPlayedEvent), UpdateMinionPlayedData);
        EventManager.Instance.AddPerformListener(typeof(OnMinionDiedEvent), UpdateMinionDiedData);
    }

    public void UpdateMinionPlayedData(EventTrigger eventTrigger)
    {
        var minionPlayedEvent = eventTrigger as OnMinionPlayedEvent;

        if (minionPlayedEvent.minion.OwnerID == 1)
        {
            player1MinionsOnBoard.Add(minionPlayedEvent.minion);
        }
        else
        {
            player2MinionsOnBoard.Add(minionPlayedEvent.minion);
        }
    }

    public void UpdateMinionDiedData(EventTrigger eventTrigger)
    {
        var minionDiedEvent = eventTrigger as OnMinionDiedEvent;

        if (minionDiedEvent.minion.OwnerID == 1)
        {
            player1MinionsOnBoard.Remove(minionDiedEvent.minion);
        }
        else
        {
            player2MinionsOnBoard.Remove(minionDiedEvent.minion);
        }
    }
}