using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinnerName : MonoBehaviour
{
    public TMP_Text winnerName;
    public VictoryManager victoryManager;

    private void Update()
    {
        winnerName.text = "Player n°" + victoryManager.playerWinID + "  WIN";
    }
}
