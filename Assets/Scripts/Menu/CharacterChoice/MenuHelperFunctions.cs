using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class MenuHelperFunctions : MonoBehaviour
{
    public static bool[] playersReady = new bool[4] { false, false, false, false };
    public static bool[] playersJoined = new bool[4] { false, false, false, false };

    public UnityEvent OnOpenMenu;


    //lobby variables
    public int playerIndex = 1;
    public GameObject playerPanel;

    //new variables
    public int chosenCharacter;
    [SerializeField] Sprite icone1;
    [SerializeField] Sprite icone2;
    public bool playStartCountdown;
    int chosenMap;
    public GameObject characterPrefab1;
    public GameObject characterPrefab2;

    List<ScriptablePlayerInfo> playerInfoScriptable;
    public ScriptablePlayerInfo player1Info;
    public ScriptablePlayerInfo player2Info;
    public ScriptablePlayerInfo player3Info;
    public ScriptablePlayerInfo player4Info;

    public List<bool> hasJoined;
    public List<int> ready;


    private void Start()
    {
        chosenMap = PlayerPrefs.GetInt("ChosenMap", 1);
        OnOpenMenu.Invoke();

        playerInfoScriptable = new List<ScriptablePlayerInfo> { player1Info, player2Info, player3Info, player4Info };
        hasJoined = new List<bool> { false, false, false, false };
        ready = new List<int>();
    }

    public void PlayerJoined()
    {
        playersJoined[playerIndex - 1] = true;

        playerInfoScriptable[0].playerID = 1;
        playerInfoScriptable[1].playerID = 2;
        playerInfoScriptable[2].playerID = 3;
        playerInfoScriptable[3].playerID = 4;
    }

    private void Update()
    {
        PlayerReady();
        Debug.Log(ready.Count);
    }

    void PlayerReady()
    {
        //playersReady[playerIndex - 1] = true;

        bool allPlayersReady = true;
        int readyCount = 0;

        //for(int i = 0; i < hasJoined.Count; i++)
        //{
        //    if (ready.Count >= 2)
        //    {
        //        readyCount++;
        //    }
        //    else
        //    {
        //        allPlayersReady = false;
        //    }
        //}

        if(ready.Count >= 2)
        {
            //readyCount++;
            SceneManager.LoadScene("Level_" + chosenMap);
        }

        

        if (allPlayersReady == true && readyCount >= 1)
        {
            //playStartCountdown = true;
            SceneManager.LoadScene("Level_" + chosenMap);
        }
    }



    public void ChosenCharacter1()
    {
        GameObject iconeGameObject = playerPanel.transform.Find("Player").transform.Find("Icone").gameObject;
        Image iconeImage = iconeGameObject.GetComponent<Image>();
        iconeImage.sprite = icone1;
        iconeImage.color = Color.white;

        //desactiver le panel bouton et activer le panel ready
        playerPanel.transform.Find("ButtonPanel").gameObject.SetActive(false);
        playerPanel.transform.Find("ReadyPanel").gameObject.SetActive(true);

        //chosenCharacter = 1;

        playerInfoScriptable[playerIndex - 1].exist = true;
        playerInfoScriptable[playerIndex - 1].playerPrefab = characterPrefab1;

        //is ready
        playersReady[playerIndex - 1] = true;
        ready.Add(playerIndex - 1);

    }

    public void ChosenCharacter2()
    {
        GameObject iconeGameObject = playerPanel.transform.Find("Player").transform.Find("Icone").gameObject;
        Image iconeImage = iconeGameObject.GetComponent<Image>();
        iconeImage.sprite = icone2;
        iconeImage.color = Color.white;

        //desactiver le panel bouton et activer le panel ready
        playerPanel.transform.Find("ButtonPanel").gameObject.SetActive(false);
        playerPanel.transform.Find("ReadyPanel").gameObject.SetActive(true);

        //chosenCharacter = 2;

        playerInfoScriptable[playerIndex - 1].exist = true;
        playerInfoScriptable[playerIndex - 1].playerPrefab = characterPrefab2;
        ready.Add(playerIndex - 1);

        //is ready
        playersReady[playerIndex - 1] = true;
        ready.Add(playerIndex - 1);
    }

    public void OnCancel()
    {
        //cancel ready
        if (playersReady[playerIndex - 1] == true)
        {
            //activate the choice panel and deactivate the ready panel
            playerPanel.transform.Find("ButtonPanel").gameObject.SetActive(true);
            playerPanel.transform.Find("ReadyPanel").gameObject.SetActive(false);

            //player not ready
            playersReady[playerIndex - 1] = false;
            ready.Remove(playerIndex - 1);

            //reset icone to grey scare
            GameObject iconeGameObject = playerPanel.transform.Find("Player").transform.Find("Icone").gameObject;
            Image iconeImage = iconeGameObject.GetComponent<Image>();
            iconeImage.sprite = null;
            iconeImage.color = Color.gray;          

            //foreach (MenuHelperFunctions menuHelper in GameObject.FindObjectsOfType<MenuHelperFunctions>())
            //{
            //    playStartCountdown = false;
            //    //playerPanel.transform.Find("Player").transform.Find("Player/Team X (TMP)").GetComponent<TextMeshProUGUI>().text = "Player " + playerIndex + " : Team " + "1"; ;
            //}
        }
        //cancel join
        else if (playersJoined[playerIndex - 1] == true)
        {
            playerPanel.transform.Find("Player").gameObject.SetActive(false);
            playerPanel.transform.Find("ButtonPanel").gameObject.SetActive(false);
            playerPanel.transform.Find("JoinPanel").gameObject.SetActive(true);

            playerPanel.transform.Find("EventSystemPlayer").GetComponent<MultiplayerEventSystem>().SetSelectedGameObject(null);

            playerPanel.transform.Find("EventSystemPlayer").GetComponent<MultiplayerEventSystem>().SetSelectedGameObject(playerPanel.transform.Find("JoinPanel").transform.Find("JoinButton").gameObject);

            playersJoined[playerIndex - 1] = false;
            hasJoined[playerIndex - 1] = false;

            playerInfoScriptable[playerIndex - 1].exist = false;
            Debug.Log("Cancel Join" + playerIndex);
        }
    }
    //private bool HasChosenCharacter(int playerIndex)
    //{
    //    return chosenCharacter > 0 && playersReady[playerIndex - 1];
    //}

    public void ChangeBoolValue(int playerId)
    {
        hasJoined[playerId] = true;
    }
}