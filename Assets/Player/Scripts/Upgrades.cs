using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour {

    static float speedMultiplier;
    static int projectileLifeBonus;
    static int guns;
    static int lifesBonus;

    private void Start()
    {
        setGuns(1);
        setSpeedMultiplier(1f);
        setProjectileLifeBonus(0);
        setLifesBonus(0);
    }

    //Getters
    public static float getSpeedMultiplier()
    {
        return speedMultiplier;
    }
    public static int getProjectileLifeBonus()
    {
        return projectileLifeBonus;
    }
    public static int getGuns()
    {
        return guns;
    }
    public static int getLifesBonus()
    {
        return lifesBonus;
    }

    // Setters
    public static void setSpeedMultiplier(float set)
    {
        speedMultiplier = set;
    }
    public static void setProjectileLifeBonus(int set)
    {
        projectileLifeBonus = set;
    }
    public static void setGuns(int set)
    {
        if (set <= 5) 
            guns = set;
    }
    public static void setLifesBonus(int set)
    {
        lifesBonus = set;
    }
    // Uppers
    public static void upSpeedMultiplier()
    {
        speedMultiplier *= 0.77f;
    }
    public static void upProjectileLifeBonus()
    {
        projectileLifeBonus += 1;
    }
    public static void upGuns()
    {
        if(guns < 3)
            guns += 1;
    }
    public static void upLifesBonus()
    {
        lifesBonus += 1;
    }
}
