using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SniperShooting : MonoBehaviour {
    public float stageOneCooldown;
    public float stageThreeCooldown;
    float cooldown;
    float timer;
    System.Random rd = new System.Random();
    public GameObject bullet;

	// Use this for initialization
	void Start () {
        timer = 0;
        if (SpawnScript.stage < 3) cooldown = stageOneCooldown;
        else cooldown = stageThreeCooldown;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (rd.Next(10) > 7) Instantiate(bullet, transform.position, transform.rotation);
            timer = cooldown;
        }
	}
}
