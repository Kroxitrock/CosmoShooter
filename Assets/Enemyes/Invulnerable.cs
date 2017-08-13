using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invulnerable : MonoBehaviour {

	
	void Update () {
        
         this.GetComponent<CapsuleCollider2D>().enabled = !Lifes.invPlayer;
	}
}
