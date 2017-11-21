using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getUpgradeName : MonoBehaviour {
    public Text txt;
	void Update () {
        switch (transform.name)
        {
            case "ChoiceOne":
                txt.text = ChooseUpgrades.choiceOne;
                break;
            case "ChoiceTwo":
                txt.text = ChooseUpgrades.choiceTwo;
                break;
        }
	}
}
