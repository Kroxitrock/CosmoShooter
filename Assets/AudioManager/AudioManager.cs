using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;
    //public AudioMixerGroup mixerGroup;

    public GameObject[] sounds;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Play("Theme");
    }
    public void Play(string name)
    {
        Debug.Log("Instantiating " + name);
        foreach (GameObject sound in sounds)
        {
            if (sound.name.Contains(name))
            {
                Instantiate(sound);
                Debug.Log("Instantiated " + sound);
                break;
            }
        }
    }

    private void Update()
    {
        if (!Toggle.toggle)
            AudioListener.volume = 0;
        else AudioListener.volume = 1;
    }
}
