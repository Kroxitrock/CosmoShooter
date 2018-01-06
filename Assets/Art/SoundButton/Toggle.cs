using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour {
    public Sprite On;
    public Sprite Off;
    public static bool toggle;
    Animator animator;
    void Start ()
    {
        
        GetComponent<Image>().sprite = On;
        toggle = true;
        animator = GetComponent<Animator>();
    }

    public void OnClick()
    {
        toggle = !toggle;
        Debug.Log("Toggled Sound: " + toggle);
        if (toggle) GetComponent<Image>().sprite = On;
        else GetComponent<Image>().sprite = Off;
    }
}
