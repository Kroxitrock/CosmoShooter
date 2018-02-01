using UnityEngine;
using System.Collections;

public class DestroyAfter : MonoBehaviour
{
    public float timer;

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(destroy()); 
    }
}
