using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDeathScreen : MonoBehaviour {
    public static bool isDead = false;
    public GameObject Black;
    public GameObject Red;
    public GameObject YouDied;
    public GameObject Stage;
    public GameObject NumberStage;
    public GameObject Button;

    void Update () {
        if (isDead)
        {
            Black.SetActive(true);
            Red.SetActive(true);
            YouDied.SetActive(true);
            Stage.SetActive(true);
            NumberStage.SetActive(true);
            Button.SetActive(true);
        }
        else
        {
            Black.SetActive(false);
            Red.SetActive(false);
            YouDied.SetActive(false);
            Stage.SetActive(false);
            NumberStage.SetActive(false);
            Button.SetActive(false);

        }
	}
}
