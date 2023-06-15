using UnityEngine;

public class DamageToEnemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyTakeDamage zombie))
        {
            zombie.TakeDamage();
            PoolManager.instance.ReturnObject(this.gameObject);
        }
    }
}
