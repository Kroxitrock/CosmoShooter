using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour
{
    public int lives;
    bool invulnerable = false;
    public float cooldown;
    float timer;
    public static bool invPlayer;
    public static int killed;
    public static int PlayerLives;
    private void Start()
    {
        if(SpawnScript.stage >= 2)
        {
            if (gameObject.name == "TopEnemy(Clone)")
                lives = 2;
        }
        if(SpawnScript.stage >= 4)
        {
            if (gameObject.name.Contains("Zigzag"))
                lives = 2;
        }
        if (gameObject.tag == "Player")
        {
            PlayerLives = lives;
            killed = 0;
            ShowDeathScreen.isDead = false;
            invPlayer = false;
        }
    }

    private void FixedUpdate()
    {
        if (gameObject.tag == "Player")
        {
            PlayerLives = lives;
        }
        timer -= Time.deltaTime;
        if (timer <= 0) invulnerable = false;
        else invulnerable = true;
        if (gameObject.tag == "Player")
            invPlayer = invulnerable;
    }

    void dropHealth()
    {
        lives--;

        if (lives <= 0)
        {

            if (gameObject.name == "Leader(Clone)")
                MovementComands.isLeaderDead = true;
            if (gameObject.tag != "Missle" && gameObject.tag != "EnemyMissle" && gameObject.tag != "Player")
            {
                FindObjectOfType<AudioManager>().Play("ExplosionSound");
                FindObjectOfType<Explosion>().Explode(transform.position, gameObject.name);
            }
            switch (gameObject.tag)
            {
                case "Enemy":
                    if (transform.name.Contains("Boss"))
                        SpawnScript.KillBoss(SpawnScript.stage);
                    Destroy(gameObject);
                    killed++;
                    break;
                case "Player":
                    if (lives + Upgrades.getLifesBonus() <= 0)
                    {

                        ShowDeathScreen.isDead = true;
                        FindObjectOfType<ShowDeathScreen>().EndGame();
                        Debug.Log("Killed");
                        FindObjectOfType<AudioManager>().Play("ExplosionSound");
                        FindObjectOfType<Explosion>().Explode(transform.position, "Player");
                        Destroy(gameObject);
                    }
                    break;
                case "Missle":
                    if (lives + Upgrades.getProjectileLifeBonus() <= 0)
                        Destroy(gameObject);
                    break;
                default:
                    Destroy(gameObject);
                    break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Wall")
        {
            Debug.Log("Wall, " + gameObject.name);
            Destroy(gameObject);

        }
        else switch (gameObject.tag)
        {
            case "Player":
                if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "EnemyMissle")
                {
                    Debug.Log("Invulnerable : " + invulnerable);
                    if (!invulnerable)
                    {
                        timer = cooldown;
                        dropHealth();
                    }
                }
                break;
            case "Enemy":
                    Debug.Log(gameObject.name);
                if (coll.gameObject.tag != "Enemy" && coll.gameObject.tag != "EnemyMissle")
                {
                    if ((transform.position.x <= 3.15 && transform.position.x >= -3.15) && (transform.position.y <= 5.05))
                        dropHealth();
                }
                break;
            case "EnemyMissle":
                if (coll.gameObject.tag == "Player")
                {
                        FindObjectOfType<Explosion>().hit(transform.position);
                        dropHealth();
                }
                break;
            case "Missle":
                if (coll.gameObject.tag == "Enemy")
                {
                    FindObjectOfType<Explosion>().hit(transform.position);
                    dropHealth();
                }
                break;
            default:
                dropHealth();
                break;
        }
    }
}
