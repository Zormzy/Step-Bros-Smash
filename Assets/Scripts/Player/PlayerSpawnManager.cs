using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{
    public Transform[] spawnPositions;
    public UiManager uiManager;

    void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.gameObject.GetComponent<PlayerInfos>().playerID = playerInput.playerIndex + 1;
        playerInput.gameObject.GetComponent<PlayerInfos>().team = playerInput.playerIndex + 1; //a suppr en créant les menus
        playerInput.gameObject.GetComponent<PlayerInfos>().startPos = spawnPositions[playerInput.playerIndex].position;
        uiManager.newPlayerJoined = true;
    }
}
