using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void Start()
    {
        int score = CountScore.score;
        int record = PlayerPrefs.GetInt("Record");

        if(score > record)
        {
            scoreText.text = "Новый рекорд: " + score;
            PlayerPrefs.SetInt("Record", score);
        }
        else
        {
            scoreText.text = "Набрано очков: " + score;
        }
    }

    public void ComeBackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
