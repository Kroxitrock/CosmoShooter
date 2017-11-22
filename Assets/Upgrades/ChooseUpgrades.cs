using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseUpgrades {
    public static string choiceOne;
    public static string choiceTwo;

    

    
    string[] upgrades;
    string[] helper;
    int size;
        

    void set()
    {
        size = 0;
        upgrades = new string[0];
        helper = new string[0];
    }

    void addUpgrade(string input)
    {
        helper = new string[size];
        for (int counter = 0; counter < upgrades.Length; counter++)
        {
            helper[counter] = upgrades[counter];
        }
        size++;
        upgrades = new string[size];
        for (int counter = 0; counter < helper.Length; counter++)
        {
            upgrades[counter] = helper[counter];
        }
        upgrades[size - 1] = input;
    }

    void getWeapon()
    {
        Types bullet = Types.BULLET;
        Types shockwave = Types.SHOCKWAVE;
        Types rocket = Types.ROCKET;

        switch (PlayerInfo.ammo.name)
        {
            case "Bullet":
                addUpgrade("ShockWave");
                addUpgrade("Rocket");
                break;
            case "ShockWave":
                addUpgrade("Bullet");
                addUpgrade("Rocket");
                break;
            case "Rocket":
                addUpgrade("Bullet");
                addUpgrade("ShockWave");
                break;
        }
    }

    void getUpgrades()
    {
        if (Upgrades.getGuns() < 5)
        {
            addUpgrade("Guns");
        }
        if(Upgrades.getLifesBonus() < 2)
        {
            addUpgrade("LifeBonus");
        }
        if(Upgrades.getProjectileLifeBonus() < 3)
        {
            addUpgrade("AmmoLife");
        }
        if(Upgrades.getSpeedMultiplier() < 5)
        {
            addUpgrade("Speed");
        }
        getWeapon();
    }
    void chooseUpgrades() {
        choiceOne = upgrades[Random.Range(0, size)];
        while ((choiceTwo = upgrades[Random.Range(0, size)]) == choiceOne) ;
    }
    




    
    private void Start()
    {
        choiceOne = null;
        choiceTwo = null;
    }
    public void initialize()
    {
        set();
        getUpgrades();
        chooseUpgrades();
        CharacterController.pousedForUpgrades = true;
        Time.timeScale = 0;

    }

}
