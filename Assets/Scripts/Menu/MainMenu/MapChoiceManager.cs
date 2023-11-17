using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapChoiceManager : MonoBehaviour
{
    public void Map1()
    {
        PlayerPrefs.SetInt("ChosenMap", 1);
        SceneManager.LoadScene("CharacterChoice");
    }

    public void Map2()
    {
        PlayerPrefs.SetInt("ChosenMap", 2);
        SceneManager.LoadScene("CharacterChoice");
    }
}
