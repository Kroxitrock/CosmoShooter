using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extend : MonoBehaviour {
    public float ext;
	
	void Update () {
        if(transform.localScale.x < 6f && !CharacterController.poused)
            transform.localScale = new Vector2(transform.localScale.x * ext, transform.localScale.y * ext);
    }
}
