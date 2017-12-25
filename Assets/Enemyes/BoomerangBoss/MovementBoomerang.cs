using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBoomerang : MonoBehaviour {
    Vector2 dest;
    public float speed;
    bool chasingPlayer;
    // Use this for initialization
    void Start () {
        chasingPlayer = true;
        dest = CharacterController.PlayerPos;
	}

    void chasePlayer()
    {
        Debug.Log("Chasing Player: " +
            dest);
        transform.position = Vector2.MoveTowards(transform.position, dest, speed);
        if (Vector2.Distance(transform.position, dest) <= 0.001f)
        {
            chasingPlayer = false;
        }
    }

    void goBack()
    {
        Debug.Log("Going back to boss: " + Position.getPos());
        transform.position = Vector2.MoveTowards(transform.position, Position.getPos(), speed);
        if (Vector2.Distance(transform.position, Position.getPos()) < 0.001f)
        {
            chasingPlayer = true;
            dest = CharacterController.PlayerPos;
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (chasingPlayer)
            chasePlayer();
        else goBack();
	}
}
