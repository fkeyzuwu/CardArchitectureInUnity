using UnityEngine;
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

        EventManager.Instance.OnMinionPlayed += UpdateMinionPlayedData;
        EventManager.Instance.OnMinionDied += UpdateMinionDiedData;
    }

    public void UpdateMinionPlayedData(OnMinionPlayedEvent minionPlayedEvent)
    {
        if (minionPlayedEvent.minion.OwnerID == 1)
        {
            player1MinionsOnBoard.Add(minionPlayedEvent.minion);
        }
        else
        {
            player2MinionsOnBoard.Add(minionPlayedEvent.minion);
        }
    }

    public void UpdateMinionDiedData(OnMinionDiedEvent minionDiedEvent)
    {
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