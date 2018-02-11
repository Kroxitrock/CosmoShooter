using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_drop : MonoBehaviour {

    public float speed;
    Vector2 dir;
    private void Start()
    {
        if (SpawnScript.stage > 3)
        {
            dir = CharacterController.PlayerPos * 10;
        }
        else dir = new Vector2(transform.position.x, -15);
    }

    void FixedUpdate()
    {
       transform.position = Vector2.MoveTowards(transform.position, dir, speed);
    }
}
