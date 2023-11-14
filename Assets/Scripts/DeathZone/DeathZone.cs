using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeathZone : MonoBehaviour
{
    [SerializeField] Transform respawnPosition;
    public VictoryManager victoryManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = respawnPosition.position;
            other.gameObject.GetComponent<PlayerInfos>().life -= 1;
            if(other.gameObject.GetComponent<PlayerInfos>().life <= 0)
            {
                victoryManager.playerAlive.Remove(other.gameObject.GetComponent<PlayerInfos>());

                other.gameObject.SetActive(false);
                //bloquer le controller pour ne pas pouvoir respawn
                //other.gameObject.GetComponent<PlayerInput>().DeactivateInput();
            }

            Debug.Log(other.gameObject.GetComponent<PlayerInfos>().life);
        }
    }
}
