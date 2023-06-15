using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTuchPlayer : MonoBehaviour
{
    private string _endScene = "GameOverMenu";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerRotate>(out PlayerRotate player))
        {
            EventBus.SceneOpen(_endScene);
        }
    }
}
