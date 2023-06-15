using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletObj;

    void Start()
    {
        InvokeRepeating(nameof(Shoot), 0f, 0.1f);
    }

    private void Shoot()
    {
        GameObject bullet = PoolManager.instance.RentObject(_bulletObj);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
    }
}
