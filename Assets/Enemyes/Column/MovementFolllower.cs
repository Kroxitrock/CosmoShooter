using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementFolllower : MonoBehaviour {
    Vector3 pos;
    public float speed;
    System.Random rd = new System.Random();
    bool foundDestination;

    private void Start()
    {
        foundDestination = false;
        pos = transform.position;
    }
    void follow()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, speed);
    }
    void mayhem()
    {
        if (!foundDestination)
        {
            pos = new Vector3((float)rd.Next(-310, 310) / 100f, (float)rd.Next(-500, 500) / 100f);
            foundDestination = true;
        }
        follow();
        if (Vector2.Distance(pos, transform.position) <= 0.02)
            foundDestination = false;

    }
    void rotate()
    {
        Vector3 moveDirection = gameObject.transform.position - pos;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg + 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    void FixedUpdate ()
    {
        if (!MovementComands.isLeaderDead && !CharacterController.poused)
        {
            if (Vector2.Distance(pos, transform.position) <= 0.02)
            {
                pos = MovementComands.pos;
            }
            follow();
        }
        else if (!CharacterController.poused)
            mayhem();
        rotate();
	}
}
