using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAmmo : MonoBehaviour {
   
    void Update () {
        GameObject.Find("Bullet").transform.position = new Vector2(-30, 30);
        GameObject.Find("ShockWave").transform.position = new Vector2(-30, 30);
    }
}
