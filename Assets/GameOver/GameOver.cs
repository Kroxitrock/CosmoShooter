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
}
