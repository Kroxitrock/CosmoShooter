using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRocket : MonoBehaviour {

    public GameObject[] objs;
    public float speed;
    private Vector2 targetPoint;
    private Quaternion targetRotation;
    float xspeed = 0;
    void Update()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(xspeed, speed);
        objs = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach (var obj in objs)
        {
            if ((transform.position - obj.transform.position).magnitude < 4)
            {
                if(obj.transform.position.y > transform.position.y)
                {
                    if (obj.transform.position.x > transform.position.x)
                        xspeed = 1.5f;
                    else if (obj.transform.position.x < transform.position.x)
                        xspeed = -1.5f;
                    targetPoint = new Vector3(obj.transform.position.x, transform.position.y) - transform.position;
                    targetRotation = Quaternion.LookRotation(-targetPoint, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.0f);
                }
            }
        }
    }
}
