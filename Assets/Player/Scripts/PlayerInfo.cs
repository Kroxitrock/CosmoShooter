using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    public GameObject BULLET;
    public GameObject SHOCKWAVE;

    Types ammoType;
    public static GameObject ammo;

    public static float cooldown;

    public static int aquiredPoints = 0;

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
        }
        
    }



    void getCD()
    {
        switch (ammo.name)
        {
            case "Bullet":
                cooldown = 0.3f;
                break;
            case "ShockWave":
                cooldown = 0.5f;
                break;
        }
    }


    private void FixedUpdate()
    {
        chooseTypes();
        getCD();
    }
}
