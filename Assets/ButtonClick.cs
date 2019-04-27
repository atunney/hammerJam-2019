using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public void RestartGame() {
        SceneManager.LoadScene("MainScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
