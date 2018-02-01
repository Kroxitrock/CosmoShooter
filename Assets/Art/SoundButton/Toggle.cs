using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour {
    public Sprite On;
    public Sprite Off;
    public static bool toggle;
    Animator animator;
    void Start ()
    {
        toggle = FindObjectOfType<AudioManager>().GetSound();
        changeSprite();
    }
    void changeSprite()
    {
        if (toggle) GetComponent<Image>().sprite = On;
        else GetComponent<Image>().sprite = Off;
    }
    public void OnClick()
    {
        toggle = FindObjectOfType<AudioManager>().ToggleSound();
        changeSprite();
        Debug.Log("Toggled Sound: " + toggle);
    }
}
