using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameObject gameOver;
    public GameObject restartButton;
    public static void showStuff() {
        gameOver.SetActive(true);
    }

    void Awake() {
        if (gameOver == null) {
            gameOver = this.gameObject;
        }
        gameOver.SetActive(false);
    }


}
