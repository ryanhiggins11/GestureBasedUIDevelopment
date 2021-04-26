using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Ryan Higgins
 * G00337350
 * Final Year Gesture Based UI Development Project
 * Updates players score
 */

public class GameScore : MonoBehaviour
{
    Text scoreTextUI;
    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreTextUI = GetComponent<Text>();
    }

    // Update is called once per frame
    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0: 000000}", score);
        scoreTextUI.text = scoreStr;
    }
}
