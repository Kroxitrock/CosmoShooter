using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBeamBoss : MonoBehaviour {
    public float cooldown;
    public float ChargeTime;
    public float HideTime;
    float timer;
    public GameObject beamHead;
    public GameObject beamBody;

    void Start () {
        timer = cooldown;	
	}
	
	void FixedUpdate () {
        timer -= Time.deltaTime;
        if(timer <= ChargeTime)
        {
            beamHead.SetActive(true);
        }
        if(timer <= 0)
        {
            beamBody.SetActive(true);
        }
        if(timer <= -HideTime)
        {
            beamHead.SetActive(false);
            beamBody.SetActive(false);
            timer = cooldown;
        }
	}
}
