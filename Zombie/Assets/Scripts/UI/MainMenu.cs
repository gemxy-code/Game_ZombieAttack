using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //Find information for UI code with S.O.L.I.D. principles 

    [SerializeField] private TextMeshProUGUI recordText;
    private int record;

    private string _gameScene = "GameScene";

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
        EventBus.SceneOpen(_gameScene);
    }

    private void UpdateButtonSound()
    {
        if(isSound)
        {
            SoundButton.image.sprite = soundTX; 
        }
        else
        {
            SoundButton.image.sprite = muteTX;
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
