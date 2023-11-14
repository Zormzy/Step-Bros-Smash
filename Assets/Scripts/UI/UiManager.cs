using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Image[] iconCharacters;
    public TMP_Text[] playersName;

    [SerializeField] private float p1Damages;
    [SerializeField] private float p2Damages;
    [SerializeField] private float p3Damages;
    [SerializeField] private float p4Damages;

    public TMP_Text P1DamagesPercent;
    public TMP_Text P2DamagesPercent;
    public TMP_Text P3DamagesPercent;
    public TMP_Text P4DamagesPercent;

    private PlayerInfos[] playerInfos; 

    void Start()
    {
        playerInfos = FindObjectsOfType<PlayerInfos>();
    }

    private void Update()
    {
        playerInfos = FindObjectsOfType<PlayerInfos>();

        foreach (PlayerInfos player in playerInfos)
        {            
            switch (player.playerID)
            {
                case 1:
                    p1Damages = player.damagesPercent;
                    break;
                case 2:
                    p2Damages = player.damagesPercent;
                    break;
                case 3:
                    p3Damages = player.damagesPercent;
                    break;
                case 4:
                    p4Damages = player.damagesPercent;
                    break;
            }
        }

        P1DamagesPercent.text = p1Damages + "%";
        P2DamagesPercent.text = p2Damages + "%";
        P3DamagesPercent.text = p3Damages + "%";
        P4DamagesPercent.text = p4Damages + "%";
    }
}
