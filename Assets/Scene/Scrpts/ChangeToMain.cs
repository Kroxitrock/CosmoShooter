using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToMain : MonoBehaviour {
    public float WaitTime;
	IEnumerator ChangeScene()
    {
        yield return new WaitForSecondsRealtime(WaitTime);
        SceneManager.LoadScene("Scene/MainScene");
    }
    // Use this for initialization
	void Start () {
        StartCoroutine(ChangeScene());
	}
	
}
