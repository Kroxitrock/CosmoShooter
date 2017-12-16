using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTopEnemy : MonoBehaviour {

    public float movementSpeed;
    Vector2 dest;
    void Start()
    {
        dest = new Vector2(transform.position.x, -20);
    }
    
    void FixedUpdate()
    {
        if(!CharacterController.poused &&  !CharacterController.pousedForUpgrades)

            transform.position = Vector2.MoveTowards(transform.position, dest, movementSpeed);
    }
}
