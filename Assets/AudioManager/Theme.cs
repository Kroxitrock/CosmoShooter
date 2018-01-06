using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theme : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
