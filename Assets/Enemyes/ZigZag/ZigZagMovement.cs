using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMovement : MonoBehaviour {
    public float speed;
    float x1;
    float x2;
    float x;
    float _x;
    Vector3 pos;


	void Start () {
        x1 = 0.2f;
        x2 = transform.position.x;
        x = x2;
        _x = -x;
        pos = getdest();
	}
	float changeX()
    {
        if (x == x1)
            x = x2;
        else x = x1;
        return x;
    }
    float getY()
    {
        return transform.position.y - 2.2f;
    }
    float revertX()
    {
        if (x == x2)
            x = _x;
        else x = x2;
        return x;
    }
    Vector3 getdest()
    {
        if (SpawnScript.stage < 4)
            return new Vector3(revertX(), getY());
        return new Vector3(changeX(), getY());
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
    // Update is called once per frame
    void FixedUpdate () {
        if (Vector3.Distance(pos, transform.position) <= 0.01 )
            pos = getdest();
        transform.position = Vector3.MoveTowards(transform.position, pos, speed);
        rotate();
    }
}
