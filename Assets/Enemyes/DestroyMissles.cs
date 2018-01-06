using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMissles : MonoBehaviour {

    void OnDestroy()
    {
        GameObject[] enemyMissles = GameObject.FindGameObjectsWithTag("EnemyMissle");
        foreach(GameObject enemyMissle in enemyMissles)
        {
            Destroy(enemyMissle);
        }
    }
}
