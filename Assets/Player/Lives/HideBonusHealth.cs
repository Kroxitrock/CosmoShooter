using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBonusHealth : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
        string name = transform.name;
        name = name.Substring(6);
        Debug.Log(name);
        int id = Convert.ToInt32(name);
        id -= 3;
        
        if (id <= Upgrades.getLifesBonus())
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);

	}
}
