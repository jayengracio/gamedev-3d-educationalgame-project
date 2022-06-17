using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    public void Open()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("character_nearby", doorOpen);

    }
}
