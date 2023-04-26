using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject BulletObj;
    [SerializeField] private Transform GunPosition;

    void Start()
    {
        Time.timeScale = 1;
        InvokeRepeating(nameof(Shoot), 0f, 0.1f);
    }


    private void Shoot()
    {
        Instantiate(BulletObj, GunPosition.position, GunPosition.rotation);
    }
}
