using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberShooting : MonoBehaviour {
    public float cooldown;
    float time = 0;
    public GameObject bomb;

	void Update () {
        time = time - Time.deltaTime;
        if (time <= 0)
        {
            if(Random.Range(0, 10) < 2)
                Instantiate(bomb, transform.position, transform.rotation);
            time = cooldown;
        }
	}
}
