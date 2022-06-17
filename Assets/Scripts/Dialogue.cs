using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public bool DestroyAtEnd;
    public GameObject questionManager;
    public bool questionEnabled;
    public GameObject actor;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        textComponent.text = string.Empty;
        //startDialog();
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        var gamepad = Gamepad.current;

        if (keyboard.eKey.wasPressedThisFrame || (gamepad != null && gamepad.buttonSouth.wasPressedThisFrame))
        {
            if (textComponent.text == lines[index])
            {
                ContinueNextLine();
            }

            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

    }

    public void startDialog()
    {
        index = 0;
        // Disables Player movement input
        GameObject.Find("Player").GetComponent<InputManager>().enabled = false;
        // Disables Player movement input
        GameObject.Find("Player").GetComponent<PlayerInteract>().enabled = false;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // Type each character of the sentence 1 by 1
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void ContinueNextLine()
    {
        if (index < lines.Length -1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }

        else
        {
            textComponent.text = string.Empty;
            gameObject.SetActive(false);

            // Disables Player movement input
            GameObject.Find("Player").GetComponent<InputManager>().enabled = true;
            // Disables Player movement input
            GameObject.Find("Player").GetComponent<PlayerInteract>().enabled = true;

            if (questionEnabled == true)
            {
                //Debug.Log("Questionnaire found");
                questionManager.GetComponent<QuestionManager>().startMCQ();
            }

            if (DestroyAtEnd == true)
            {
                actor.SetActive(false);
            }
        }
    }
}
