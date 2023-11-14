using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfos : MonoBehaviour
{
    public int playerID;
    public Vector3 startPos;
    public int life;
    public float damagesPercent;
    public int team;

    void Start()
    {
        transform.position = startPos;
        life = 3;
    }

    private void Update()
    {
        if(life <= 0)
        {
            Death();
        }
    }

    void Death()
    {

    }
}
