using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recepticle : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.GetComponent<Flushable>() != null) {
            Flushable flushable = col.gameObject.GetComponent<Flushable>();
            if (flushable.isGood == true) {
                Score.AddScore(flushable.scoreValue);
                Debug.Log("score");
            }
            else {
                Timer.Penalty(flushable.time);
                Debug.Log("penalty");
            }
            Debug.Log(col.gameObject);
        }
    }
}
