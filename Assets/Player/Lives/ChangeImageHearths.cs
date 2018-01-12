using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageHearths : MonoBehaviour {
    public Sprite empty;
    public Sprite full;
    // Update is called once per frame
    void Update()
    {
        string name = transform.name;
        name = name.Substring(6);
        int id = Convert.ToInt32(name);

        if (Lifes.PlayerLives + Upgrades.getLifesBonus() < id)
        {
            GetComponent<Image>().sprite = empty;
        }
        else
        {
            GetComponent<Image>().sprite = full;
        }
    }
}
