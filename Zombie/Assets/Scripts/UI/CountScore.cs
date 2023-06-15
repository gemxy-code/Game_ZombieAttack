using TMPro;
using UnityEngine;

public class CountScore : MonoBehaviour
{
    //Find information for UI code with S.O.L.I.D. principles 

    [SerializeField] public TextMeshProUGUI _scoreText;
    public static int Score;

    private void OnEnable()
    {
        EventBus.OnEnemyDied += AddScore;
        Score = 0;        
    }

    private void OnDisable()
    {
        EventBus.OnEnemyDied -= AddScore;
    }

    private void AddScore(int value)
    {
        Score += value;
        _scoreText.text = Score.ToString();
    }
}
