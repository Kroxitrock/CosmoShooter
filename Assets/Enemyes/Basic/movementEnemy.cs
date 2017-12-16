using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementEnemy : MonoBehaviour {

    public float movementSpeed;
    Vector2 dest;
    int movementDirection = 0;
    private void Start()
    {
        if (transform.position.x < 0)
        {
            transform.localScale *= -1;
            movementDirection = 1;
        }
        else movementDirection = -1;
    }
    void FixedUpdate () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(movementDirection * movementSpeed, 0);
	}
}
