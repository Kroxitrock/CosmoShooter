using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementComands : MonoBehaviour {
    System.Random rd = new System.Random();
    public static Vector2 pos;
    public float speed;
    public static bool isLeaderDead;
    bool foundDestination;
    Vector3 dest;

    void Follow(Vector2 target)
    { 
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }

    void ChooseRandom()
    {

        if (!foundDestination)
        {
            dest = new Vector2((float)rd.Next(-310, 310) / 100f, (float)rd.Next(-500, 500) / 100f);
            foundDestination = true;
        }
        Follow(dest);
        if (Vector2.Distance(pos, transform.position) <= 0.02)
            foundDestination = false;

    }
    void FollowPlayer()
    {
        Follow(CharacterController.PlayerPos);
    }

    private void Start()
    {
        isLeaderDead = false;
    }
    void Rotate()
    {
        Vector3 moveDirection = gameObject.transform.position - dest;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg + 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void FixedUpdate () {
        if (!CharacterController.poused)
        {
            if (SpawnScript.stage <= 3)
            {
                ChooseRandom();
            }
            else
            {
                FollowPlayer();
            }
        }
        Rotate();
        pos = transform.position;
    }
}
