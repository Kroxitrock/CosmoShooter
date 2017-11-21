using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowonPouse : MonoBehaviour {
    public GameObject BackGround;
    public GameObject ChoiceOne;
    public GameObject ChoiceTwo;
	
	void Update () {
        if (CharacterController.pousedForUpgrades)
        {
            BackGround.SetActive(true);
            ChoiceOne.SetActive(true);
            ChoiceTwo.SetActive(true);
        }
	}
}
