using UnityEngine;

public class PlayerInfos : MonoBehaviour
{
    public int playerID;
    public Vector3 startPos;
    public int life;
    public float damagesPercent;
    public int team;

    public int chosenCharacter;
    public GameObject characterPrefab1;
    public GameObject characterPrefab2;

    void Start()
    {
        Debug.Log(playerID);
        DontDestroyOnLoad(gameObject);
        LoadPlayerInput();

        life = 3;
    }

    private void Update()
    {
        Debug.Log(playerID);

    }

    public void SetPrefab()
    {
        if(chosenCharacter == 1)
        {

        }
        else if(chosenCharacter == 2)
        {

        }
    }
    public void SavePlayerInput()
    {        
        PlayerPrefs.SetInt("PlayerID", playerID);
        PlayerPrefs.Save();
    }

    public void LoadPlayerInput()
    {
        playerID = PlayerPrefs.GetInt("PlayerID");
    }

    public void ResetDamages()
    {
        damagesPercent = 0;
    }
}
