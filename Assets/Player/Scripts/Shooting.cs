using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    
    float timer;
    Vector2 transformpos;
    
	
	void FixedUpdate ()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Time.timeScale = 1;
            timer = PlayerInfo.cooldown;
            transformpos = new Vector2(transform.position.x, transform.position.y + 0.8f);
            try{Instantiate(PlayerInfo.ammo, transformpos, transform.rotation);}
            catch{}
        }
    }
}
