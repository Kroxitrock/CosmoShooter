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
        if(!GameObject.Find("Theme(Clone)"))
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
    public bool GetSound() {
        if (AudioListener.volume == 1)
            return true;
        else
            return false;
    }
    public bool ToggleSound()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
        }
        else {
            AudioListener.volume = 0;
        }
        return GetSound();
    }
    private void Update()
    {
        if (!Toggle.toggle)
            AudioListener.volume = 0;
        else AudioListener.volume = 1;
    }
}
