using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {


    //Stages and Enemyes----------------------------------------------------------------------------------------------------
    public int [] stageSize;
    int currentStage = 0;
    public static int stage;
    bool ready;
    public static int remaining;
    public GameObject NormalEnemy;
    public GameObject NormalTopEnemy;
    public GameObject Leader;
    public GameObject Follower;
    public GameObject ZigzagEnemy;
    public GameObject Sniper;
    //Stages and Enemyes(end)----------------------------------------------------------------------------------------------------


    private void Start()
    {
        ShowDeathScreen.isDead = false;
        bossPool = new bool[4];
        for (int i = 0; i < 4; i++)
            bossPool[i] = true;
        boss = new bool[5];
        for (int i = 0; i < 5; i++)
            boss[i] = false;
        spawned = new bool[5];
        for (int i = 0; i < 5; i++)
            spawned[i] = false;
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

    public GameObject rightTopCorner;
    public GameObject leftTopCorner;

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
    int deadpool = 0;


    //Choose Spawns----------------------------------------------------------------------------------------------------
    GameObject goThroughTop(int gtcounter)
    {
        switch (gtcounter)
        {
            case 0:
                return ttopCenter;
            case 1:
                return ttopRight;
            case 2:
                return ttopLeft;
            default:
                return ttopLeft;
        }
    }


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

    GameObject chooseCorner()
    {
        if (rd.Next(2) == 0) return leftTopCorner;
        else return rightTopCorner;
    }
    //Choose Spawns(end)----------------------------------------------------------------------------------------------------


    //Spawn Enemy Functions----------------------------------------------------------------------------------------------------
    int howManyToSpawn;
    bool startedWaiting = false;
    float timerWaiting = 1f;

    void SpawnNormallEnemy()
    { 
        if (GameObject.FindWithTag("Enemy") == null) counter = 0;
        if (counter == 0)
        {
            top = chooseTop();
            mid = chooseMid();
            bot = chooseBot();
            if (!startedWaiting)
            {
                timerWaiting = 0.5f;
                startedWaiting = true;
            }
            else
            {
                timerWaiting -= Time.deltaTime; 
            }
        }
        timer -= Time.deltaTime;
        if (timer <= 0 && remaining > 0 && counter < howManyToSpawn/3 && timerWaiting <= 0f)
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

    private int c;
    
    void SpawnNormallTopEnemy()
    {
        GameObject spawnPoint;
        if (GameObject.FindWithTag("Enemy") == null) counter = 0;
        if (counter == 0)
        {
            if (!startedWaiting)
            {
                timerWaiting = 0.5f;
                startedWaiting = true;
            }
            else
            {
                timerWaiting -= Time.deltaTime;
            }
        }
        timer -= Time.deltaTime;

        
        if (timer <= 0 && remaining > 0 && counter < howManyToSpawn && timerWaiting <= 0f)
        {
            if(stage < 3)
            { 
                spawnPoint = choosetTop();
                startedWaiting = false;
                Instantiate(NormalTopEnemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
                remaining--;
                counter++;
            }
            else if(stage < 5)
            {
                spawnPoint = goThroughTop(c);
                if (remaining > 0 && counter <= 6)
                {
                    Instantiate(NormalTopEnemy, new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y), spawnPoint.transform.rotation);
                    remaining--;
                    counter++;
                }
                if (remaining > 0 && counter <= 6)
                {
                    Instantiate(NormalTopEnemy, new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y + 2), spawnPoint.transform.rotation);
                    remaining--;
                    counter++;
                }
                c++;
                if (counter >= 6)
                    c = -1;
            }
            else
            {
                spawnPoint = goThroughTop(c);
                if (remaining > 0 && counter <= 9)
                {
                    Instantiate(NormalTopEnemy, new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y + 1), spawnPoint.transform.rotation);
                    remaining--;
                    counter++;
                }
                if (remaining > 0 && counter <= 9)
                {
                    Instantiate(NormalTopEnemy, new Vector2(spawnPoint.transform.position.x + 1.5f, spawnPoint.transform.position.y), spawnPoint.transform.rotation);
                    remaining--;
                    counter++;
                }
                if (remaining > 0 && counter <= 9)
                {
                    Instantiate(NormalTopEnemy, new Vector2(spawnPoint.transform.position.x - 1.5f, spawnPoint.transform.position.y), spawnPoint.transform.rotation);
                    remaining--;
                    counter++;
                }
                c++;
                if(counter >= 9)
                    c = 0;
            }

            timer = cooldown;
        }
              

    }

    GameObject spawnPoint;
    void spawnCollumn()
    {

        if (GameObject.FindWithTag("Enemy") == null) counter = 0;
        if (counter == 0)
        {
            if (!startedWaiting)
            {
                timerWaiting = 0.5f;
                startedWaiting = true;
            }
            else
            {
                timerWaiting -= Time.deltaTime;
            }
        }
        timer -= Time.deltaTime;
        if (timer <= 0 && remaining > 0 && counter < howManyToSpawn && timerWaiting <= 0f)
        {

            startedWaiting = false;
            if (c == 0)
            {
                spawnPoint = chooseCorner();
                Instantiate(Leader, spawnPoint.transform.position, spawnPoint.transform.rotation);
            }
            else
                Instantiate(Follower, spawnPoint.transform.position, spawnPoint.transform.rotation);
            remaining--;
            counter++;
            c++;
            timer = cooldown;
        }
    }

    void spawnZigzag()
    {

        if (GameObject.FindWithTag("Enemy") == null) counter = 0;
        if (counter == 0)
        {
            if (!startedWaiting)
            {
                timerWaiting = 0.5f;
                startedWaiting = true;
            }
            else
            {
                timerWaiting -= Time.deltaTime;
            }
        }
        timer -= Time.deltaTime;
        if (timer <= 0 && remaining > 0 && counter < howManyToSpawn && timerWaiting <= 0f)
        {
            
            startedWaiting = false;
            if(stage < 4)
            {
                if (c == 0)
                {
                    spawnPoint = chooseCorner();
                }
                Instantiate(ZigzagEnemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
                remaining--;
                counter++;
                c++;
            }
            else
            {
                Instantiate(ZigzagEnemy, leftTopCorner.transform.position, leftTopCorner.transform.rotation);
                remaining--;
                counter++;
                if(remaining > 0 && counter < howManyToSpawn)
                {
                    Instantiate(ZigzagEnemy, rightTopCorner.transform.position, rightTopCorner.transform.rotation);
                    remaining--;
                    counter++;
                }
            }
            timer = cooldown;
        }
    }
    void spawnSniper()
    {
        GameObject spawnPoint;

        if (GameObject.FindWithTag("Enemy") == null) counter = 0;

        if (counter == 0)
        {
            if (!startedWaiting)
            {
                timerWaiting = 0.5f;
                startedWaiting = true;
            }
            else
            {
                timerWaiting -= Time.deltaTime;
            }
        }
        timer -= Time.deltaTime;


        if (timer <= 0 && remaining > 0 && counter < howManyToSpawn && timerWaiting <= 0f)
        {
            spawnPoint = goThroughTop(c);
            Instantiate(Sniper, spawnPoint.transform.position, spawnPoint.transform.rotation);
            remaining--;
            counter++;
            c++;
            if (counter >= 3)
                c = -1;
            timer = cooldown;
        }
    }
    //Spawn Enemy Functions(end)----------------------------------------------------------------------------------------------------



    //BossHandler-------------------------------------------------------------------------------------------------------------------
    static bool[] boss;
    bool[] spawned;

    public GameObject RamBoss;
    public GameObject ShotBoss;
    public GameObject BeamBoss;
    public GameObject LaserBoss;
    public GameObject BoomerangBoss;
    public GameObject HomingRocketBoss;

    public GameObject bossSpawnPoint;
    

    bool[] bossPool;
    
    bool IsBossDead(int stage)
    {
        return boss[stage - 1];
    }
    bool IsBossSpawned(int stage)
    {
        return spawned[stage - 1];
    }
    public static void KillBoss(int stage)
    {
        boss[stage - 1] = true;
    }
    void ChooseBoss()
    {
        int bosses = 4;
        for (int i = 0; i < bossPool.Length; i++)
        {
            if (bossPool[i] == false) bosses--;
        }
        int[] BossPool = new int[bosses];
        int c = 0;
        for (int i = 0; i < bossPool.Length; i++)
        {
            if (bossPool[i] == true)
            {
                BossPool[c] = i;
                c++;
            }
        }
        switch (BossPool[rd.Next(0, BossPool.Length)])
        {
            case 0:
                bossPool[0] = false;
                Instantiate(ShotBoss, bossSpawnPoint.transform.position, bossSpawnPoint.transform.rotation);
                break;
            case 1:
                bossPool[1] = false;
                Instantiate(BeamBoss, bossSpawnPoint.transform.position, bossSpawnPoint.transform.rotation);
                break;
            case 2:
                bossPool[2] = false;
                Instantiate(LaserBoss, bossSpawnPoint.transform.position, bossSpawnPoint.transform.rotation);
                break;
            case 3:
                bossPool[3] = false;
                Instantiate(BoomerangBoss, spawnPoint.transform.position, bossSpawnPoint.transform.rotation);
                break;
        }
    }

    void SpawnBoss(int stage)
    {
        if (stage == 1)
            Instantiate(RamBoss, bossSpawnPoint.transform.position, bossSpawnPoint.transform.rotation);
        else if (stage == 5)
            Instantiate(HomingRocketBoss, bossSpawnPoint.transform.position, bossSpawnPoint.transform.rotation);
        else
            ChooseBoss();
        spawned[stage - 1] = true;
    }
    //BossHandler-------------------------------------------------------------------------------------------------------------------



    //Choose Enemy------------------------------------------------------------------------------------------------------------------
    void chooseEnemy()
    {
        int helper;
        if ((helper = rd.Next(100)) <= 20)
        {
            enemyNum = 1;
            Debug.Log("Bombers");
            if (stage == 1)
            {
                howManyToSpawn = 9;
                cooldown = 1.2f;
            }
            else if(stage >= 2)
            {
                howManyToSpawn = 12;
                cooldown = 1.4f;
            }
        }
        else if (helper <= 40)
        {
            Debug.Log("Fighters");
            enemyNum = 2;
            if(stage < 3)
            {
                howManyToSpawn = 8;
                cooldown = 1f;
            }else if(stage == 3 || stage == 4)
            {
                c = -1;
                howManyToSpawn = 6;
                cooldown = 0.1f;
            }
            else if(stage == 5)
            {
                c = 0;
                howManyToSpawn = 9;
                cooldown = 0;
            }
        }
        else if(helper <= 60)
        {
            
            Debug.Log("Collumn");
            c = 0;
            enemyNum = 3;
            if (stage >= 4)
                howManyToSpawn = 7;
            else 
                howManyToSpawn = 5;
            cooldown = 0.7f;
        }
        else if(helper <= 80)
        {
            Debug.Log("ZigZag");
            c = 0;
            enemyNum = 4;
            howManyToSpawn = 10;
            cooldown = 0.8f;
        }
        else
        {
            Debug.Log("Sniper");
            c = -1;
            enemyNum = 5;
            howManyToSpawn = 3;
            if (stage < 3)
                cooldown = 0.2f;
            else cooldown = 0f;
        }
    }
    //Choose Enemy(end)-------------------------------------------------------------------------------------------------------------
    int enemyNum;

    void clearMissles()
    {
        GameObject[] em = GameObject.FindGameObjectsWithTag("EnemyMissle");
    }
    void reset()
    {
        Lifes.killed = 0;
        deadpool = 0;
        clearMissles();
    }
    void UpStage()
    {
        ready = false;
        stage++;
        currentStage = stageSize[stage];
        Debug.Log("Stage = " + stage + "\n StageSize = " + currentStage);
    }
    private void FixedUpdate()
    {
        Debug.Log("Ready = " + ready);
        Debug.Log("Deadpool = " + deadpool);
        Debug.Log("Killed = " + Lifes.killed);
        if (stage == 6)
            FindObjectOfType<ShowDeathScreen>().EndGame();
        if (ready && stage < 6)
        {
            if (stage == 0)
                UpStage();
            else if (IsBossDead(stage))
            {
                reset();
                new ChooseUpgrades().initialize();
                UpStage();
            }
            else if(!IsBossSpawned(stage))
            {
                SpawnBoss(stage);
            }
        }
        if (!CharacterController.pousedForUpgrades) 
        {
            if (deadpool <= Lifes.killed)
            {
                if (currentStage > 0)
                {
                    chooseEnemy();
                    currentStage -= howManyToSpawn;
                    remaining = howManyToSpawn;
                    deadpool = howManyToSpawn + Lifes.killed;
                }
                else if (currentStage <= 0)
                {
                    ready = true;
                    Debug.Log("Stage " + stage + " compleated! :)");
                }
            }

            if (!ready)
            {
                switch (enemyNum)
                {
                    case 1:
                        SpawnNormallEnemy();
                        break;
                    case 2:
                        SpawnNormallTopEnemy();
                        break;
                    case 3:
                        spawnCollumn();
                        break;
                    case 4:
                        spawnZigzag();
                        break;
                    case 5:
                        spawnSniper();
                        break;
                }
            }
        }
    }
}
