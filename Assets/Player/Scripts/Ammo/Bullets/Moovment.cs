using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moovment : MonoBehaviour {
    private void Awake()
    {
        FindObjectOfType<AudioManager>().Play("BulletSound");
    }
    public float speed;
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
	}
}
