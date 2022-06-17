using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public GameObject actor;

    public TextMeshProUGUI scoreText;
    int score = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + "/5 Items Found";
    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = score.ToString() + "/5 Items Found";

        if (score == 5)
        {
            actor.SetActive(true);
            scoreText.text = "All items found. Find Sir Sadge!";
        }
    }
}
