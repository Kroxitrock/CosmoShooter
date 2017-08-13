    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    public GameObject pouseText;
    public static bool poused = false;
    public GameObject ammo;
    public float cooldown;
    float timer;
    Vector2 transformpos;
    

    void Update () {
        if (Input.GetMouseButton(0)){
            
            
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (poused){
                if ((pos.x <= transform.position.x + 0.5 && pos.x >= transform.position.x - 0.5) && (pos.y <= transform.position.y + 0.8 && pos.y >= transform.position.y - 0.8))
                {
                    timer -= Time.deltaTime;
                    poused = false;
                    pouseText.SetActive(false);
                    Time.timeScale = 1;
                    transform.position = pos;
                    if (timer <= 0){
                        timer = cooldown;
                        transformpos = new Vector2(transform.position.x, transform.position.y + 0.8f);
                        Instantiate(ammo, transformpos, transform.rotation);
                    }
                }
            }
            else {
                timer -= Time.deltaTime;
                pouseText.SetActive(false);
                Time.timeScale = 1;
                transform.position = pos;
                if (timer <= 0) {
                    timer = cooldown;
                    transformpos = new Vector2(transform.position.x, transform.position.y + 0.8f);
                    Instantiate(ammo, transformpos, transform.rotation);
                }
                    
            }
        }
        else {
            poused = true;
            Time.timeScale = 0;
            pouseText.SetActive(true);
        }
    }
}
