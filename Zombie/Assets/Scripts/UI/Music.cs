using UnityEngine;

public class Music : MonoBehaviour
{
    //Find information for UI code with S.O.L.I.D. principles 

    private AudioSource musicSource;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.mute = PlayerPrefs.GetInt("isSound") == 0;
    }
}
