using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeathZone : MonoBehaviour
{
    [SerializeField] Transform respawnPosition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = respawnPosition.position;
            other.gameObject.GetComponent<PlayerInfos>().life -= 1;

            Debug.Log(other.gameObject.GetComponent<PlayerInfos>().life);
        }
    }
}
