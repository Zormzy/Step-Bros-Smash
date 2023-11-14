using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    private bool canEndGame;
    public GameObject victoryPanel;
    public List<PlayerInfos> playerAlive;
    public int playerWinID;

    private void Update()
    {

        if(playerAlive.Count >= 2)
        {
            canEndGame = true;
        }

        if(canEndGame && playerAlive.Count == 1)
        {
            playerWinID = playerAlive[0].playerID;
            victoryPanel.SetActive(true);
        }
    }
}
