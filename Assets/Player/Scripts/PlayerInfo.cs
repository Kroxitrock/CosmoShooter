using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    public GameObject BULLET;
    public GameObject SHOCKWAVE;
    public GameObject ROCKET;

    public static Types ammoType;
    public static GameObject ammo;

    public static float cooldown;
    
    

    void Start () {
        ammoType = Types.BULLET;
	}



    void chooseTypes()
    {
        if (ammoType == Types.BULLET)
        {
            Debug.Log("Using bullets...");
            ammo = BULLET;
        }else if (ammoType == Types.SHOCKWAVE)
        {
            Debug.Log("Using shockwaves...");
            ammo = SHOCKWAVE;
        }else if (ammoType == Types.ROCKET)
        {
            Debug.Log("Using rockets...");
            ammo = ROCKET;
        }

    }
    
    void getCD()
    {
        switch (ammo.name)
        {
            case "Bullet":
                cooldown = 0.3f * Upgrades.getSpeedMultiplier();
                break;
            case "ShockWave":
                cooldown = 1.25f * Upgrades.getSpeedMultiplier();
                break;
            case "Rocket":
                cooldown = 0.6f * Upgrades.getSpeedMultiplier();
                break;
        }
    }


    private void FixedUpdate()
    {
        chooseTypes();
        getCD();
    }
}
