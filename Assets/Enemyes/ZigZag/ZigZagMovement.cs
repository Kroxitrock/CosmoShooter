using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMovement : MonoBehaviour {
    public float speed;
    float x1;
    float x2;
    float x;
    float _x;
    Vector2 pos;


	void Start () {
        x1 = 0.2f;
        x2 = transform.position.x;
        x = x2;
        _x = -x;
        pos = getdest();
	}
	float changeX()
    {
        if (x == x1)
            x = x2;
        else x = x1;
        return x;
    }
    float getY()
    {
        return transform.position.y - 2.2f;
    }
    float revertX()
    {
        if (x == x2)
            x = _x;
        else x = x2;
        return x;
    }
    Vector2 getdest()
    {
        if (SpawnScript.stage <= 1)
            return new Vector2(revertX(), getY());
        return new Vector2(changeX(), getY());
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (Vector2.Distance(pos, transform.position) <= 0.01 )
            pos = getdest();
        transform.position = Vector2.MoveTowards(transform.position, pos, speed);
    }
}
