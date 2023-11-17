using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    List<ScriptablePlayerInfo> playerInfoScriptable;
    public ScriptablePlayerInfo player1Info;
    public ScriptablePlayerInfo player2Info;
    public ScriptablePlayerInfo player3Info;
    public ScriptablePlayerInfo player4Info;

    void Start()
    {       
        playerInfoScriptable = new List<ScriptablePlayerInfo> { player1Info, player2Info, player3Info, player4Info };

        StartCoroutine("SpawnPlayers");
    }

    IEnumerator SpawnPlayers()
    {
        for (int i = 0; i < playerInfoScriptable.Count ; i++)
        {
            if(playerInfoScriptable[i].exist)
            {
                GameObject player = Instantiate(playerInfoScriptable[i].playerPrefab) as GameObject;
                player.transform.position = GameObject.Find("Spanw" + (i + 1).ToString()).transform.position;
                player.transform.rotation = GameObject.Find("Spanw" + (i + 1).ToString()).transform.rotation;

                if (MenuHelperFunctions.playersReady[i] == false)
                {
                    foreach (Transform transform in player.transform)
                    {
                        Destroy(transform.gameObject);
                        //player.GetComponent<PlayerHandler>().enabled = false;
                    }
                }

                yield return new WaitForSeconds(0.01f);
            }            
        }
    }
}
