using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {
    public static GameObject ammo;
    public static float cooldown;
    public static int aquiredPoints = 0;
	void Start () {
        ammo = Types.BULLET;
	}
    private void Update()
    {
        switch (ammo.name)
        {
            case "Bullet":
                cooldown = 0.3f;
                break;
        }
    }
}
