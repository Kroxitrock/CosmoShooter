using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBonusLives : MonoBehaviour {


    public GameObject health4;
    public GameObject health5;

	void Update () {
	    if(Upgrades.getLifesBonus() > 0)
        {
            health4.SetActive(true);
            if (Upgrades.getLifesBonus() > 1)
            {
                health5.SetActive(true);
            }
        }	
	}
}
