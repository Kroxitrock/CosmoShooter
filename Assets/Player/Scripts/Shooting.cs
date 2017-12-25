using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    
    float timer;
    Vector2 transformpos;
    
	
	void FixedUpdate ()
    {
        if (!CharacterController.pousedForUpgrades)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Time.timeScale = 1;
                timer = PlayerInfo.cooldown;
                if (Upgrades.getGuns() == 1 || Upgrades.getGuns() == 3 || Upgrades.getGuns() == 5)
                {
                    transformpos = new Vector2(transform.position.x, transform.position.y + 0.8f);
                    try { Instantiate(PlayerInfo.ammo, transformpos, transform.rotation); }
                    catch { }
                }
                if (Upgrades.getGuns() > 1)
                {
                    transformpos = new Vector2(transform.position.x + 0.7f, transform.position.y);
                    try { Instantiate(PlayerInfo.ammo, transformpos, transform.rotation); }
                    catch { }
                    transformpos = new Vector2(transform.position.x - 0.7f, transform.position.y);
                    try { Instantiate(PlayerInfo.ammo, transformpos, transform.rotation); }
                    catch { }
                }
                if (Upgrades.getGuns() > 3)
                {
                    transformpos = new Vector2(transform.position.x + 0.4f, transform.position.y + 0.2f);
                    try { Instantiate(PlayerInfo.ammo, transformpos, transform.rotation); }
                    catch { }
                    transformpos = new Vector2(transform.position.x - 0.4f, transform.position.y + 0.2f);
                    try { Instantiate(PlayerInfo.ammo, transformpos, transform.rotation); }
                    catch { }
                }

            }
        }
    }
       
}
