using UnityEngine;

[CreateAssetMenu(menuName = "PlayerInfo")]
public class ScriptablePlayerInfo : ScriptableObject
{
    public int playerID;
    public int team;
    public GameObject playerPrefab;
    public bool exist;
}
