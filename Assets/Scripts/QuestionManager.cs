using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public GameObject[] Questions;
    public GameObject MCQ;
    public GameObject incorrect;
    int currentQuestion;

    public void startMCQ()
    {
        // Disables Player movement input
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;        
        GameObject.Find("Player").GetComponent<InputManager>().enabled = false;

        MCQ.SetActive(true);

        for (int i=0; i < Questions.Length; i++)
        {
            Questions[i].SetActive(false);
        }

        Questions[currentQuestion].SetActive(true);

        incorrect.SetActive(false);
    }

    public void correctAnswer()
    {
        if (currentQuestion + 1 != Questions.Length)
        {
            Questions[currentQuestion].SetActive(false);
            currentQuestion++;
            Questions[currentQuestion].SetActive(true);
        }
        
        else
        {
            // Enable Player movement input
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.Find("Player").GetComponent<InputManager>().enabled = true;
            MCQ.SetActive(false);
        }
    }

    public void missionComplete()
    {
        // Enable Player movement input
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject.Find("Player").GetComponent<InputManager>().enabled = false;
        MCQ.SetActive(false);
    }

    public void incorrectAnswer()
    {
        Questions[currentQuestion].SetActive(false);
        incorrect.SetActive(true);
    }

    public void restart()
    {
        currentQuestion = 0;
        incorrect.SetActive(false);
        Questions[currentQuestion].SetActive(true);
    }

    public void Pass()
    {
        // Enable Player movement input
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("Player").GetComponent<InputManager>().enabled = true;
        MCQ.SetActive(false);
    }
}
