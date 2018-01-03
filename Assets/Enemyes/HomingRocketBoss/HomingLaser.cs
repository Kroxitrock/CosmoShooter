using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingLaser : MonoBehaviour {
    bool pastPlayer;
    Vector3 oldDest;
    public float speed;
    // Use this for initialization
	void Start () {
        pastPlayer = false;
	}
    void Rotate()
    {
        Vector3 moveDirection = gameObject.transform.position - (Vector3)CharacterController.PlayerPos;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg + 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (CharacterController.PlayerPos.y >= transform.position.y)
            pastPlayer = true;
        if ( !pastPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, CharacterController.PlayerPos, speed);
            Rotate();
            oldDest = CharacterController.PlayerPos;
            Debug.Log("Dest: " + oldDest);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, oldDest*10, speed);
        }
    }
}
