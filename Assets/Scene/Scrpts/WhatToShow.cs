using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatToShow : MonoBehaviour {
    public GameObject Win;
    public GameObject Lose;
    public GameObject Reset;
	void Start () {
        Debug.Log(ShowDeathScreen.isDead);
        if (ShowDeathScreen.isDead)
        {
            Lose.SetActive(true);
        }
        else Win.SetActive(true);
        Reset.SetActive(true);
	}
}
