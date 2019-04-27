using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score score;
    public static int scoreCounter = 0;
    public Text scoreKeeper;
    void Awake() {
        score = this;
    }

    void Update () {
        scoreKeeper.text = ("Points: " + Score.scoreCounter); //Showing the Score on the Canvas
    }

    public static void AddScore(int addToScore) {
        Score.scoreCounter += addToScore;
    }
}
