using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour {
    public GameObject Background;
    public GameObject ChoiceOne;
    public GameObject ChoiceTwo;




    public void onClick()
    {
        CharacterController.pousedForUpgrades = false;
        setInactive();
        switch (transform.name)
        {
            case "ChoiceOne":
                doUpgrade(ChooseUpgrades.choiceOne);
                break;
            case "ChoiceTwo":
                doUpgrade(ChooseUpgrades.choiceTwo);
                break;
        }
        Debug.Log(transform.name);
    }

    private void doUpgrade(string choice)
    {
        switch (choice)
        {
            case "Guns":
                Debug.Log("Guns");
                Upgrades.upGuns();
                break;
            case "LifeBonus":
                Debug.Log("LifeBonus");
                Upgrades.upLifesBonus();
                break;
            case "AmmoLife":
                Debug.Log("AmmoLife");
                Upgrades.upProjectileLifeBonus();
                break;
            case "Speed":
                Debug.Log("Speed");
                Upgrades.upSpeedMultiplier();
                break;
            case "Bullet":
                Debug.Log("Bullet");
                PlayerInfo.ammoType = Types.BULLET;
                break;
            case "ShockWave":
                Debug.Log("ShockWave");
                PlayerInfo.ammoType = Types.SHOCKWAVE;
                break;
            case "Rocket":
                Debug.Log("Rocket");
                PlayerInfo.ammoType = Types.ROCKET;
                break;

        }
    }

    private void setInactive()
    {
        Background.SetActive(false);
        ChoiceOne.SetActive(false);
        ChoiceTwo.SetActive(false);
    }
}
