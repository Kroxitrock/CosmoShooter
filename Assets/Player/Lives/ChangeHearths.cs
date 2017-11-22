using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeHearths : MonoBehaviour {

    public Sprite empty;
    public Sprite full;
	// Update is called once per frame
	void Update () {
        string name = transform.name;
        name = name.Substring(6);
        int id = Convert.ToInt32(name);

        if(Lifes.PlayerLives + Upgrades.getLifesBonus() < id)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = empty; 
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = full;
        }
    }
}
