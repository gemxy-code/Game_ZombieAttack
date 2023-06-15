using UnityEngine;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    //Find information for UI code with S.O.L.I.D. principles 

    [SerializeField] private TextMeshProUGUI scoreText;

    private string _startPage = "MainMenu";

    public void Start()
    {
        int record = PlayerPrefs.GetInt("Record");
        int score = CountScore.Score;

        if (score > record)
        {
            scoreText.text = "New record: " + score;
            PlayerPrefs.SetInt("Record", score);
        }
        else
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void ComeBackToMenu()
    {
        EventBus.SceneOpen(_startPage);
    }
}
