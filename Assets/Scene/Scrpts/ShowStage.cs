using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStage : MonoBehaviour
{

    public Text txt;


    void Update()
    {
        txt.text = "" + SpawnScript.stage;
    }
}

