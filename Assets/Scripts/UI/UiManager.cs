using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Image iconCharacter1;
    public Image iconCharacter2;
    public Image iconCharacter3;
    public Image iconCharacter4;


    public TMP_Text player1Name;
    public TMP_Text player2Name;
    public TMP_Text player3Name;
    public TMP_Text player4Name;

    [SerializeField] private float p1Damages;
    [SerializeField] private float p2Damages;
    [SerializeField] private float p3Damages;
    [SerializeField] private float p4Damages;

    public TMP_Text P1DamagesPercent;
    public TMP_Text P2DamagesPercent;
    public TMP_Text P3DamagesPercent;
    public TMP_Text P4DamagesPercent;

    public PlayerInfos[] playerInfos;
    public bool newPlayerJoined;

    [SerializeField] private GameObject p1UI;
    [SerializeField] private GameObject p2UI;
    [SerializeField] private GameObject p3UI;
    [SerializeField] private GameObject p4UI;

    private void Start()
    {
        playerInfos = FindObjectsOfType<PlayerInfos>();
    }

    private void Update()
    {
        if(newPlayerJoined)
        {
            playerInfos = FindObjectsOfType<PlayerInfos>();
            newPlayerJoined = false;
        }
        

        foreach (PlayerInfos player in playerInfos)
        {            
            switch (player.playerID)
            {
                case 1:
                    p1UI.SetActive(true);

                    p1Damages = player.damagesPercent;
                    player1Name.text = "Player" + player.playerID + "  Team " + player.team;
                    break;
                case 2:
                    p2UI.SetActive(true);

                    p2Damages = player.damagesPercent;
                    player2Name.text = "Player" + player.playerID + "  Team " + player.team;
                    break;
                case 3:
                    p3UI.SetActive(true);

                    p3Damages = player.damagesPercent;
                    player3Name.text = "Player" + player.playerID + "  Team " + player.team;
                    break;
                case 4:
                    p4UI.SetActive(true);

                    p4Damages = player.damagesPercent;
                    player4Name.text = "Player" + player.playerID + "  Team " + player.team;
                    break;
            }
        }

        P1DamagesPercent.text = p1Damages + "%";
        P2DamagesPercent.text = p2Damages + "%";
        P3DamagesPercent.text = p3Damages + "%";
        P4DamagesPercent.text = p4Damages + "%";

        
    }
}
