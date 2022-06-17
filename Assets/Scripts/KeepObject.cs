using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepObject : MonoBehaviour
{
    public GameObject[] gameObjects;
    private void Awake()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            DontDestroyOnLoad(gameObjects[i]);
        }
    }
}
