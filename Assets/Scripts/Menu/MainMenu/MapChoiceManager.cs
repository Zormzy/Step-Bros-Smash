using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapChoiceManager : MonoBehaviour
{
    public int chosenMap;
    public void Map1()
    {
        chosenMap = 1;
    }

    public void Map2()
    {
        chosenMap = 2;
    }
}
