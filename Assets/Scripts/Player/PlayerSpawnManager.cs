using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{
    public Transform[] spawnPositions;

    void OnPlayerJoined(PlayerInput playerInput)
    {

        //Debug.Log("PlayerInput ID: " + playerInput.playerIndex);

        playerInput.gameObject.GetComponent<PlayerInfos>().playerID = playerInput.playerIndex + 1;
        playerInput.gameObject.GetComponent<PlayerInfos>().startPos = spawnPositions[playerInput.playerIndex].position;
    }
}
