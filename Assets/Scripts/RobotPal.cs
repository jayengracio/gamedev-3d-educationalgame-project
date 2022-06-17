using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPal : MonoBehaviour
{
    public GameObject robot;

    public void playJump()
    {
        // Play jump animation
        robot.GetComponent<Animator>().Play("Jump");
    }

    // Awake is called before the first frame update
    void Awake()
    {
        robot.GetComponent<Animator>().Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        // When jumping animation is done, play idle animation loop again
        robot.GetComponent<Animator>().SetBool("finishedJumping", true);
    }
}
