using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfos : MonoBehaviour
{
    public int playerID;
    public Vector3 startPos;

    void Start()
    {
        transform.position = startPos;
    }
}
