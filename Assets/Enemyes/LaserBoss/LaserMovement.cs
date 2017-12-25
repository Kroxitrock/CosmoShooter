using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour {
    Vector3 dest;
    public float speed;

    void rotate()
    {
        Vector3 moveDirection = gameObject.transform.position - dest;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg + 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void Start () {
        dest = CharacterController.PlayerPos * 10;
        rotate();
	}
	
	void FixedUpdate () {
        transform.position = Vector3.MoveTowards(transform.position, dest, speed);
	}
}
