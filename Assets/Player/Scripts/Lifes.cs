using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour {
    public GameObject self;
    public int lives;
    bool invulnerable = false;
    public float cooldown;
    float timer;
    public static bool invPlayer;
    public static int killed = 0;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) invulnerable = false;
        else invulnerable = true;
        if (self.tag == "Player")
            invPlayer = invulnerable;
    }

    void dropHealth(){
        lives--;
        if (lives <= 0)
        {
            if (self.tag == "Enemy")
                killed++;
            Destroy(self);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        

        if (coll.gameObject.tag == "Wall")
            Destroy(self);
        if (self.tag != "Enemy")
        {
            if (coll.gameObject.tag == "Enemy")
            {
                if (self.tag == "Player")
                {
                    Debug.Log("Inbulnerable : " + invulnerable);
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
