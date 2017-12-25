using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectiveShooting : MonoBehaviour {
    float timer;
    public float cooldown;
    public GameObject missle;
    public float xOffset;
    public float yOffset;
	// Use this for initialization
	void Start () {
        timer = cooldown;	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(missle, new Vector2(transform.position.x + xOffset, transform.position.y + yOffset), transform.rotation);
            timer = cooldown;
        }
	}
}
