using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {
    public GameObject enemyToInstantiate;
    public GameObject topLeft;
    public GameObject midLeft;
    public GameObject botLeft;
    public GameObject topRight;
    public GameObject midRight;
    public GameObject botRight;
    public int howManyToSpawn;
    public float cooldown;
    float timer;
    

    GameObject top;
    GameObject mid;
    GameObject bot;

    int counter;

    System.Random rd = new System.Random();

    public static int remaining;


    private void Start()
    {
        remaining = howManyToSpawn;
    }


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

    void Update () {
        if (!CharacterController.poused) {
            if (GameObject.Find("Enemy(Clone)") == null) counter = 0;
            Debug.Log(remaining);
            if (counter == 0)
            {
                top = chooseTop();
                mid = chooseMid();
                bot = chooseBot();
            }
            timer -= Time.deltaTime;
            if (timer <= 0 && remaining > 0 && counter < 5)
            {
                Instantiate(enemyToInstantiate, top.transform.position, top.transform.rotation);
                remaining--;
                if(remaining > 0)
                {
                    Instantiate(enemyToInstantiate, mid.transform.position, mid.transform.rotation);
                    remaining--;
                }
                if (remaining > 0)
                {
                    Instantiate(enemyToInstantiate, bot.transform.position, bot.transform.rotation);
                    remaining--;
                }
                counter++;
                timer = cooldown;
            }
        }
    }
}
