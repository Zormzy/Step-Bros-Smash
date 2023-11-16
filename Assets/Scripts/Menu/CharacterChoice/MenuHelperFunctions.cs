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

    private void Start()
    {
        OnOpenMenu.Invoke();
    }

    private void Update()
    {
        Debug.Log(playersJoined[0]);
        Debug.Log(playersJoined[1]);
        Debug.Log(playersJoined[2]);
        Debug.Log(playersJoined[3]);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PlayerJoined()
    {
        GameObject.Find("CountdownTimer").GetComponent<TextMeshProUGUI>().text = "";
        foreach (MenuHelperFunctions menuHelper in GameObject.FindObjectsOfType<MenuHelperFunctions>())
        {
            menuHelper.StopCoroutine("LobbyCountdown");
        }
        playersJoined[playerIndex - 1] = true;


    }

    public void PlayerReady()
    {
        playersReady[playerIndex - 1] = true;

        bool allPlayersReady = true;
        int readyCount = 0;
        for (int i = 0; i < playersJoined.Length; i++)
        {
            if (playersJoined[i] == true)
            {
                playerPanel.transform.Find("Player/Team X (TMP)").GetComponent<TextMeshProUGUI>().text = "Player" + playerIndex + " : Team " + "1";

                if (playersReady[i] == false)
                {
                    allPlayersReady = false;
                }
                else
                {
                    readyCount++;
                }
            }
        }

        if (allPlayersReady == true && readyCount > 1)
        {
            transform.Find("StartPanel").gameObject.SetActive(true);
            StartCoroutine("GameStartCountdown");
        }
    }

    IEnumerator GameStartCountdown()
    {
        int countdownDuration = 10;

        int remainingTime = countdownDuration;
        for (int i = 0; i < countdownDuration; i++)
        {
            GameObject.Find("CountdownTimer").GetComponent<TextMeshProUGUI>().text = "Start\n" + remainingTime.ToString();
            yield return new WaitForSeconds(1);
            remainingTime--;
        }

        //playerPreff map choisie
        LoadScene("Level_"); //+ playerPreff
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

        playersReady[playerIndex - 1] = true;
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

        playersReady[playerIndex - 1] = true;
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

            //reset icone to grey scare
            GameObject iconeGameObject = playerPanel.transform.Find("Player").transform.Find("Icone").gameObject;
            Image iconeImage = iconeGameObject.GetComponent<Image>();
            iconeImage.sprite = null;
            iconeImage.color = Color.gray;

            //reset GameStartCountdown
            GameObject.Find("CountdownTimer").GetComponent<TextMeshProUGUI>().text = "";
            foreach (MenuHelperFunctions menuHelper in GameObject.FindObjectsOfType<MenuHelperFunctions>())
            {
                menuHelper.StopCoroutine("GameStartCountdown");
            }
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
            Debug.Log("Cancel Join" + playerIndex);
        }
    }
}
