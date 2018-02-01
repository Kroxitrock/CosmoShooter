using UnityEngine.UI;
using UnityEngine;

public class HighScore : MonoBehaviour {

	void Start () {
        if (PlayerPrefs.GetInt("CSHighScore", 0) < (SpawnScript.stage - 1))
            PlayerPrefs.SetInt("CSHighScore", (SpawnScript.stage - 1));
        gameObject.GetComponent<Text>().text += PlayerPrefs.GetInt("CSHighScore", 0);

    }
}
