using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {


    //Stages and Enemyes----------------------------------------------------------------------------------------------------
    public int stageOne;
    int currentStage;
    public static int stage;
    bool ready;
    public static int remaining;
    public GameObject NormalEnemy;
    public GameObject NormalTopEnemy;
    //Stages and Enemyes(end)----------------------------------------------------------------------------------------------------


    private void Start()
    {
        stage = 0;
        remaining = 0;
        ready = true;
    }


    //Spawns----------------------------------------------------------------------------------------------------
    public GameObject topLeft;
    public GameObject midLeft;
    public GameObject botLeft;
    public GameObject topRight;
    public GameObject midRight;
    public GameObject botRight;

    public GameObject ttopLeft;
    public GameObject ttopCenter;
    public GameObject ttopRight;

    GameObject top;
    GameObject mid;
    GameObject bot;

    GameObject left;
    GameObject right;
    GameObject center;

    //Spawns(end)----------------------------------------------------------------------------------------------------


    int counter;

    System.Random rd = new System.Random();

    float cooldown;
    float timer = 0f;
    int deadpool;


    //Choose Spawns----------------------------------------------------------------------------------------------------

    GameObject choosetTop()
    {
        int rand;
        if ((rand = rd.Next(3)) == 0) return ttopLeft;
        else if (rand == 1) return ttopCenter;
        else return ttopRight;
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


    void SpawnNormallTopEnemy()
    {
        GameObject spawnPoint;
        if (GameObject.Find("TopEnemy(Clone)") == null) counter = 0;
        if (counter == 0)
        {
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
        if (timer <= 0 && remaining > 0 && counter < 15 && timerWaiting <= 0f)
        {
            spawnPoint = choosetTop();
            startedWaiting = false;
            Instantiate(NormalTopEnemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
            remaining--;
            counter++;
            timer = cooldown;
        }
    }
    //Spawn Enemy Functions(end)----------------------------------------------------------------------------------------------------
    int enemyNum;

    private void FixedUpdate()
    {
        Debug.Log("Ready = " + ready);
        Debug.Log("Deadpool = " + deadpool);
        Debug.Log("Killed = " + Lifes.killed);

        if (stage == 0)
        {
            currentStage = stageOne;
            stage++;
        }
        if (stage == 1 && ready)
        {
            
            if (rd.Next(100) > 50)
            {
                enemyNum = 1;
                Debug.Log("Spawn 1");
                cooldown = 0.2f;
            }
            else
            {
                Debug.Log("Spawn 2");
                enemyNum = 2;
                cooldown = 0.5f;
            }
            if (currentStage > 0)
            {
                ready = false;
                howManyToSpawn = 15;
                currentStage -= howManyToSpawn;
                remaining = howManyToSpawn;
                deadpool = howManyToSpawn + Lifes.killed;
            }
            else
            {
                ready = true;
                Debug.Log("Stage " + stage + " compleated! :)");
                stage++;
            }
        }
        if (stage == 1 && !ready)
        {
            if(enemyNum == 1)
            {
                SpawnNormallEnemy();
            }
            else
            {
                SpawnNormallTopEnemy();
            }
            if (deadpool == Lifes.killed)
            {
                ready = true;
            }
        }
    }
}
