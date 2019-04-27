using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flushable : MonoBehaviour
{
    bool isActive = true;
    float movementSpeed = 2f;
    Vector2 upRight = new Vector2(1.0f, 1.0f);
    Vector2 downRight = new Vector2(1.0f, -1.0f);

    void FixedUpdate()
    {
        
        if (isActive == true) {
            //transform.Translate(Vector2.right*movementSpeed*Time.deltaTime);
            //transform.Translate(upRight*movementSpeed*Time.deltaTime);
            //transform.Translate(downRight*movementSpeed*Time.deltaTime);
        };

        if (Input.GetKey("up")) {
            transform.Translate(upRight*movementSpeed*Time.deltaTime);
        }
        else if (Input.GetKey("right")) {
            transform.Translate(Vector2.right*movementSpeed*Time.deltaTime);
        }
        else if (Input.GetKey("down")) {
            transform.Translate(downRight*movementSpeed*Time.deltaTime);
        }
    }


}
