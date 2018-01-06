using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public GameObject explosionAnim;

	public void Explode (Vector2 pos, Vector2 size)
    {
        Debug.Log("Exploding");
        GameObject explosion = Instantiate(explosionAnim, pos, transform.rotation);
        explosion.GetComponent<SpriteRenderer>().size = size;
    }
}
