using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _speedBullet;

    private void FixedUpdate()
    {
        transform.Translate(0, 0, Time.deltaTime * _speedBullet);
    }
}
