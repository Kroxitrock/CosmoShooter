using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingShotboss : MonoBehaviour {
    public float cooldown;
    public float speed;
    float timer;
    float y = -15;
    public GameObject missle;
    GameObject holder;

    void Start () {
        timer = 0f;
        holder = GameObject.Find("Holder");
    }


    Vector2 getDest(float x)
    {
        return new Vector2(x, y);
    }

    IEnumerator handleMissles(GameObject missle1, GameObject missle2, GameObject missle3, float x)
    {
        if (!CharacterController.poused)
        {
            while (true)
            {
                if(missle1)
                    missle1.transform.position = Vector2.MoveTowards(missle1.transform.position, getDest(x - 3), speed);
                if(missle2)
                    missle2.transform.position = Vector2.MoveTowards(missle2.transform.position, getDest(x), speed);
                if(missle3)
                    missle3.transform.position = Vector2.MoveTowards(missle3.transform.position, getDest(x + 3), speed);
                Debug.Log("Coroutine");
                yield return new WaitForFixedUpdate();
            }
        }
    }


	// Update is called once per frame
	void FixedUpdate () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GameObject missle1 = Instantiate(missle, holder.transform);
            GameObject missle2 = Instantiate(missle, holder.transform);
            GameObject missle3 = Instantiate(missle, holder.transform);
            missle1.transform.position = transform.position;
            missle2.transform.position = transform.position;
            missle3.transform.position = transform.position;
            StartCoroutine(handleMissles(missle1, missle2, missle3, transform.position.x));
            Debug.Log("Here");
            timer = cooldown;
        }
    }
}
