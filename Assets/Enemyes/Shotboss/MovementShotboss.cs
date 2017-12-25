using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementShotboss : MonoBehaviour {
    Vector2 dest;
    float x = 0;
    public float y;
    public float speed;
    // Use this for initialization
    void Start() {
        dest = new Vector2(x, y);
        x = 1.8f;
    }
    float toggleX()
    {
        return x = -x;
    }
	// Update is called once per frame
	void FixedUpdate () {
        if (Vector2.Distance(transform.position, dest) <= 0.01f)
            dest = new Vector2(toggleX(), y);
        transform.position = Vector2.MoveTowards(transform.position, dest, speed);
	}
}
