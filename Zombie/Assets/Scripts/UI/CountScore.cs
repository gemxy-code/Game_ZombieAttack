using TMPro;
using UnityEngine;

public class CountScore : MonoBehaviour
{

    public static int score;
    [SerializeField] public TextMeshProUGUI _scoreText;

    void Start()
    {
        score = 0; 
    }

    void Update()
    {
        _scoreText.text = score.ToString();
    }
}
