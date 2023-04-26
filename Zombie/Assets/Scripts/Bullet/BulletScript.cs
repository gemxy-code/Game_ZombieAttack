using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float _speedBullet;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ZombieAI zombie))
        {
            collision.gameObject.GetComponent<ZombieAI>().TakeDamage();
            Destroy(gameObject);
        }
    }
    

    void Update()
    {
        transform.Translate(0, 0, Time.deltaTime * _speedBullet);
    }
}
