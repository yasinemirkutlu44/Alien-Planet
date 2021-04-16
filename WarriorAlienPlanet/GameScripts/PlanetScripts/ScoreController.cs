using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public static int gameScore;
    private Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<Text>(); // Get the appropriate component
    }
    void Start()
    {
        gameScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = " Current Score: " + gameScore; // Update current score with gameScore
    }
}
