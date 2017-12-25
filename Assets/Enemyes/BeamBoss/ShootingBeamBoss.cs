using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBeamBoss : MonoBehaviour {
    public float cooldown;
    float timer;
    public GameObject beamHead;
    public GameObject beamBody;

    void Start () {
        timer = cooldown;	
	}
	
	void FixedUpdate () {
        timer -= Time.deltaTime;
        if(timer <= 0.4f)
        {
            beamHead.SetActive(true);
        }
        if(timer <= 0)
        {
            beamBody.SetActive(true);
        }
        if(timer <= -0.2f)
        {
            beamHead.SetActive(false);
            beamBody.SetActive(false);
            timer = cooldown;
        }
	}
}
