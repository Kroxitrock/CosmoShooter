    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    GameObject pouseText;
    public static bool poused = false;
    float timer;
    public static bool pousedForUpgrades = false;
    public static Vector2 PlayerPos;
    private void Start()
    {
        pouseText = GameObject.Find("Text");
        setTrue();
    }

    void setTrue()
    {
        poused = true;
        Time.timeScale = 0;
        pouseText.SetActive(true);
    }
    void setFalse(Vector2 pos)
    {
        pouseText.SetActive(false);
        Time.timeScale = 1;
        transform.position = pos;
    }

    void Update () {
        PlayerPos = transform.position;
        if (pousedForUpgrades)
        {
            poused = false;
            setFalse(new Vector2(0, 0));
        }else
        {
            if (Input.GetMouseButton(0))
            {

                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (poused)
                {
                    if ((pos.x <= transform.position.x + 0.5 && pos.x >= transform.position.x - 0.5) && (pos.y <= transform.position.y + 0.8 && pos.y >= transform.position.y - 0.8))
                    {
                        poused = false;
                        setFalse(pos);
                    }
                }
                else setFalse(pos);
            }
            else setTrue();
        }
    }
}
