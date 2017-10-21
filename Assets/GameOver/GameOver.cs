using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
    public GameObject player;
    public GameObject startingPosition;


    private void Start()
    {
            Instantiate(player, startingPosition.transform.position, startingPosition.transform.rotation);
    }
    private void Update()
    {
        if(SpawnScript.stage == 0)
            Instantiate(player, startingPosition.transform.position, startingPosition.transform.rotation);
    }
}
