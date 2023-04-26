using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recordText;
    private int record;

    private string _nextScene = "GameScene";

    [SerializeField] private Sprite muteTX;
    [SerializeField] private Sprite soundTX;
    [SerializeField] private Button SoundButton;
    private bool isSound = true;

    private void Start()
    {
        isSound = PlayerPrefs.GetInt("isSound") == 1;
        UpdateButtonSound();

        record = PlayerPrefs.GetInt("Record");
        if (record > 0)
        {
            recordText.text += " " + record;
        }
        else
        {
            recordText.text = "";
        }       
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_nextScene);       
    }

    private void UpdateButtonSound()
    {
        if(isSound)
        {
            SoundButton.image.sprite = muteTX; 
        }
        else
        {
            SoundButton.image.sprite = soundTX;
        }
    }

    public void SoundUpdate()
    {
        isSound = !isSound;
        UpdateButtonSound();        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("isSound", isSound ? 1 : 0);
    }
}
