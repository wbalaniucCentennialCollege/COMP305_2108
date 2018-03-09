using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    private int currentScore;
    private Text scoreText;

	// Use this for initialization
	void Start () {
        currentScore = 0;
        scoreText = GetComponent<Text>();
        UpdateText();
	}

    public void UpdateScore(int valueToAdd)
    {
        currentScore += valueToAdd;
        UpdateText();
    }

    void UpdateText()
    {
        scoreText.text = "Score: " + currentScore;
    }
}
