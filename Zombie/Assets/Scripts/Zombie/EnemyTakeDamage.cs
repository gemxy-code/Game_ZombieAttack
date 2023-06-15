using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;

    private float _health;

    private void OnEnable()
    {
        _health = _enemyData.Health;
    }

    public void TakeDamage()
    {
        _health--; 
        if (_health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        EventBus.EnemyDied(_enemyData.Score);
        PoolManager.instance.ReturnObject(this.gameObject);
    }

}
