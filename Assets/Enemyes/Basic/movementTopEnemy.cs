using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTopEnemy : MonoBehaviour {

    public float movementSpeed;
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, movementSpeed * (-1));
    }
}
