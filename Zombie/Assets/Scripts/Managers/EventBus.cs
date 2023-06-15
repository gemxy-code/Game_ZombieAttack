using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventBus : MonoBehaviour
{
    public static event Action <int> OnEnemyDied;

    public static void EnemyDied(int value)
    {
        OnEnemyDied?.Invoke(value);
    }

    public static void SceneOpen(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
