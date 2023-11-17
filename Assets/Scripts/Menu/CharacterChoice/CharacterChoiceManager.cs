using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterChoiceManager : MonoBehaviour
{
    public MenuHelperFunctions menuHelperFunctions;
    private bool isCountdownRunning = false;
    int chosenMap;


    private void Start()
    {
        GameObject.Find("CountdownTimer").GetComponent<TextMeshProUGUI>().text = "";
        chosenMap = PlayerPrefs.GetInt("ChosenMap", 1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        if (menuHelperFunctions.playStartCountdown && !isCountdownRunning)
        {
            isCountdownRunning = true;
            //StartCoroutine(GameStartCountdown());
        }
        else if (menuHelperFunctions.playStartCountdown == false)
        {
            isCountdownRunning = false;
            //StopCoroutine(GameStartCountdown());
            //GameObject.Find("CountdownTimer").GetComponent<TextMeshProUGUI>().text = "";
        }
    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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

        LoadScene("Level_" + chosenMap);

        // Réinitialiser les variables
        isCountdownRunning = false;
        menuHelperFunctions.playStartCountdown = false;
    }

}