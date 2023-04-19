using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource musicSource;
    private bool isSound;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        isSound = PlayerPrefs.GetInt("isSound") == 1 ? true : false;
        if(isSound)
        {
            musicSource.mute = false;
        }
        else
        {
            musicSource.mute = true;
        }
    }
}
