using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour {
    public GameObject self;
    public int lives;
    bool invulnerable = false;
    public float cooldown;
    float timer;


    void dropHealth(){
        lives--;
        if (lives <= 0)
            Destroy(self);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        timer -= Time.deltaTime;
        if (timer <= 0) invulnerable = false;
        else invulnerable = true;

        if (coll.gameObject.tag == "Wall")
            Destroy(self);
        if (self.tag != "Enemy")
        {
            if (coll.gameObject.tag == "Enemy")
            {
                if (self.tag == "Player")
                {
                    if (!invulnerable)
                    {
                        timer = cooldown;
                        dropHealth();
                    }
                }
                else dropHealth();
            }
        }
        else if(coll.gameObject.tag != "Enemy") dropHealth();
    }
}
