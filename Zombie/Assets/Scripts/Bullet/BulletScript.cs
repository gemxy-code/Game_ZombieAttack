using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float _speedBullet;
    
    //Hit enemy 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<ZombieAI>().TakeDamage();
            Destroy(gameObject);
        }
    }
    

    void Update()
    {
        //Bullet movement
        transform.Translate(0, 0, Time.deltaTime * _speedBullet);
    }
}
