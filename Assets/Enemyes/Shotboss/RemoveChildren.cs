using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveChildren : MonoBehaviour {
    GameObject Boss;
	void FixedUpdate () {
        if (!Boss)
        {
            foreach (Transform child in transform)
                GameObject.Destroy(child);
        }
	}
}
