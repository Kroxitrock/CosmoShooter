/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNormallEnemy {
    public GameObject topLeft = GameObject.Find("SpawnTopLeft");
    public GameObject midLeft = GameObject.Find("SpawnMiddleLeft");
    public GameObject botLeft = GameObject.Find("SpawnBottomLeft");
    public GameObject topRight = GameObject.Find("SpawnTopRight");
    public GameObject midRight = GameObject.Find("SpawnMiddleRight");
    public GameObject botRight = GameObject.Find("SpawnBottomRight");
    public float cooldown;
    float timer;
    int deadpool;
    public bool ready = false;

    GameObject top;
    GameObject mid;
    GameObject bot;

    int counter;

    System.Random rd = new System.Random();

    

    GameObject chooseTop()
    {
        if (rd.Next(2) == 0) return topLeft;
        else return topRight;
    }

    GameObject chooseMid()
    {
        if (rd.Next(2) == 0) return midLeft;
        else return midRight;
    }

    GameObject chooseBot()
    {
        if (rd.Next(2) == 0) return botLeft;
        else return botRight;
    }
    public bool SpawnEnemy(int howManyToSpawn, GameObject enemyToInstantiate)
    {
        deadpool = howManyToSpawn + Lifes.killed;
        SpawnScript.remaining = howManyToSpawn;
        while (Lifes.killed < deadpool)
        
            if (!CharacterController.poused)
            {
                if (GameObject.Find("Enemy(Clone)") == null) counter = 0;
                if (counter == 0)
                {
                    top = chooseTop();
                    mid = chooseMid();
                    bot = chooseBot();
                }
                timer -= Time.deltaTime;
                if (timer <= 0 && SpawnScript.remaining > 0 && counter < 5)
                {
                    SpawnScript.instantiateObj(enemyToInstantiate, top.transform.position, top.transform.rotation);
                    SpawnScript.remaining--;
                    if (SpawnScript.remaining > 0)
                    {
                        SpawnScript.instantiateObj(enemyToInstantiate, mid.transform.position, mid.transform.rotation);
                        SpawnScript.remaining--;
                    }
                    if (SpawnScript.remaining > 0)
                    {
                        SpawnScript.instantiateObj(enemyToInstantiate, bot.transform.position, bot.transform.rotation);
                        SpawnScript.remaining--;
                    }
                    counter++;
                    timer = cooldown;
                }
            }
        
        
        return true;
    }
}
*/