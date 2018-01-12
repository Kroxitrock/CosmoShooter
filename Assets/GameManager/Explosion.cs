using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public GameObject explosionAnim;
    public GameObject hitAnim;

    public void hit(Vector2 pos)
    {
        Debug.Log("Hit");
        GameObject hit = Instantiate(hitAnim, pos, transform.rotation);
        FindObjectOfType<AudioManager>().Play("HitSound");
    }

	public void Explode (Vector2 pos, string Name)
    {
        Debug.Log("Exploding");
        GameObject explosion = Instantiate(explosionAnim, pos, transform.rotation);
        if (Name.Contains("Boss"))
        {
            explosion.transform.localScale *= 2;
        }
    }
}
