using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public void RestartGame() {
        SceneManager.LoadScene("SampleScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
