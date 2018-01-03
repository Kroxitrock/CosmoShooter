using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRamBoss : MonoBehaviour {
    Vector2 dest;
    float x = 0;
    public float ramY;
    public float y;
    public float speed;
    public float cooldown;
    float timer;
    bool haveRammed;
    // Use this for initialization
    void Start()
    {
        haveRammed = false;
        dest = new Vector2(x, y);
        x = 1.8f;
    }
    float ToggleX()
    {
        return x = -x;
    }
    void Ram()
    {
        if (!haveRammed)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, ramY), speed + 0.02f);
            if (transform.position.y == ramY)
                haveRammed = true;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, y), speed + 0.02f);
            if (transform.position.y == y)
            {
                haveRammed = false;
                timer = cooldown;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Ram();
        }
        else
        {
            if (Vector2.Distance(transform.position, dest) <= 0.01f)
                dest = new Vector2(ToggleX(), y);
            transform.position = Vector2.MoveTowards(transform.position, dest, speed);
        }
    }
}
