using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
    private void Awake()
    {
        name = gameObject.name;
        if(name.Contains("(Clone)"))
            name = name.Remove(name.Length - 7);
        FindObjectOfType<AudioManager>().Play(name + "Sound");
    }
}
