
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flushable : MonoBehaviour
{
    public int time = 50;
    public int scoreValue = 50;
    public bool isGood;
    public bool isActive = true;

    public int currentDirection = 1; 

    public float movementSpeed = 5f;


    private static Dictionary<int, Vector2> directions = new Dictionary<int, Vector2>();

    void Awake() {
        if (directions.Count == 0) {
            directions.Add(0, new Vector2(1, 1));
            directions.Add(1, new Vector2(1, 0));
            directions.Add(2, new Vector2(1, -1));
            directions.Add(3, new Vector2(0, -1));
            directions.Add(4, new Vector2(-1, -1));
            directions.Add(5, new Vector2(-1, 0));
            directions.Add(6, new Vector2(-1, 1));
            directions.Add(7, new Vector2(0, 1));
        }

        
    }

    private void FixedUpdate() {
        if (isActive) {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
        
    }


}


    // public bool forceApplied = false;
    // public Rigidbody2D rb2D;
    // public float power = 50f;

    // void FixedUpdate()
    // {
    //     if (isActive && !forceApplied) {
    //         rb2D.AddForce(Vector2.right * power);
    //         forceApplied = true;
    //     }
      
    // }
