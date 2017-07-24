using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementEnemy : MonoBehaviour {

    public float movementSpeed;
    bool isFirst = true;
    int movementDirection = 0;
    void Update () {
        if (isFirst)
        {
            if (transform.position.x < 0) movementDirection = 1;
            else movementDirection = -1;
            isFirst = false;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(movementDirection * movementSpeed, 0);
	}
}
