using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosition : MonoBehaviour {
    Vector2 dest;
    public float speed;
    public float y;

	void Start () {
        dest = new Vector2(transform.position.x, y);
	}
	
	void FixedUpdate () {
        transform.position = Vector2.MoveTowards(transform.position, dest, speed);
	}
}
