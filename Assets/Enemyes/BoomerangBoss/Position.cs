using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {

	static Vector2 pos;

    public static Vector2 getPos()
    {
        return pos;
    }

	void FixedUpdate () {
        pos = transform.position;
	}
}
