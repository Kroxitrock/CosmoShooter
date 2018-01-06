using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowDeathScreen : MonoBehaviour {
    public static bool isDead;

    public void EndGame() {
        SceneManager.LoadScene("Scene/EndGame");
    }
    
}
