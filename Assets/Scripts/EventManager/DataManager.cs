using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public int player1MinionsOnBoard;
    public int player2MinionsOnBoard;
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
        if (minionPlayedEvent.minionPlayed.OwnerID == 1)
        {
            player1MinionsOnBoard++;
        }
        else
        {
            player2MinionsOnBoard++;
        }
    }

    public void UpdateMinionDiedData(OnMinionDiedEvent minionDiedEvent)
    {
        if (minionDiedEvent.minionDied.OwnerID == 1)
        {
            player1MinionsOnBoard--;
        }
        else
        {
            player2MinionsOnBoard--;
        }
    }
}