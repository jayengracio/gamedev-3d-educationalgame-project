using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Interaction
    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
}
