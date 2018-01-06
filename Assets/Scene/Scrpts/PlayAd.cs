using UnityEngine.Advertisements;
using UnityEngine;

public class PlayAd : MonoBehaviour {

    private void Start()
    {
        if(Advertisement.IsReady())
            Advertisement.Show();
    }
}
