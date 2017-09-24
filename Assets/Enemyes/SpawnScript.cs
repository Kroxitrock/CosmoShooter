using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {


    //Stages and Enemyes----------------------------------------------------------------------------------------------------
    public int stageOne;
    int stage = 1;
    bool ready;
    public static int remaining = 0;
    public GameObject NormalEnemy;
    //Stages and Enemyes(end)----------------------------------------------------------------------------------------------------


    private void Start()
    {
        ready = true;
    }


    //Spawns----------------------------------------------------------------------------------------------------
    public GameObject topLeft;
    public GameObject midLeft;
    public GameObject botLeft;
    public GameObject topRight;
    public GameObject midRight;
    public GameObject botRight;

    GameObject top;
    GameObject mid;
    GameObject bot;

    //Spawns(end)----------------------------------------------------------------------------------------------------


    int counter;

    System.Random rd = new System.Random();

    public float cooldown;
    float timer = 0f;
    int deadpool;


    //Choose Spawns----------------------------------------------------------------------------------------------------
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
    //Choose Spawns(end)----------------------------------------------------------------------------------------------------


    //Spawn Enemy Functions----------------------------------------------------------------------------------------------------
    int howManyToSpawn;
    bool startedWaiting = false;
    float timerWaiting = 1f;

    void SpawnNormallEnemy()
    {
        
        if (GameObject.Find("Enemy(Clone)") == null) counter = 0;
        if (counter == 0)
        {
            top = chooseTop();
            mid = chooseMid();
            bot = chooseBot();
            if (!startedWaiting)
            {
                timerWaiting = 3f;
                startedWaiting = true;
            }
            else
            {
                timerWaiting -= Time.deltaTime; 
            }
        }
        timer -= Time.deltaTime;
        if (timer <= 0 && remaining > 0 && counter < 5 && timerWaiting <= 0f)
        {
            startedWaiting = false;
            Instantiate(NormalEnemy, top.transform.position, top.transform.rotation);
            remaining--;
            if (SpawnScript.remaining > 0)
            {
                Instantiate(NormalEnemy, mid.transform.position, mid.transform.rotation);
                remaining--;
            }
            if (SpawnScript.remaining > 0)
            {
                Instantiate(NormalEnemy, bot.transform.position, bot.transform.rotation);
                remaining--;
            }
            counter++;
            timer = cooldown;
        }
    }
    //Spawn Enemy Functions(end)----------------------------------------------------------------------------------------------------
    int enemyNum;

    private void Update()
    {
        if (stage == 1 && ready)
        {
            if (rd.Next(100) > 50)
            {
                enemyNum = 1;
                Debug.Log("Spawn 1");
            }
            else
            {
                Debug.Log("Spawn 2");
                enemyNum = 2;
            }
            if (stageOne > 0)
            {
                ready = false;
                howManyToSpawn = 15;
                remaining = howManyToSpawn;
            }
        }
        if (stage == 1 && !ready)
        {
            deadpool = howManyToSpawn + Lifes.killed;
            if(enemyNum == 1)
            {
                SpawnNormallEnemy();
            }
            else
            {
                SpawnNormallEnemy();
            } 
            if (deadpool == Lifes.killed) ready = true;
        }
    }

}
