using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invulnerable : MonoBehaviour {

	
    void FixedUpdate () {
        GetComponent<PolygonCollider2D>().enabled = !Lifes.invPlayer;
	}
}
