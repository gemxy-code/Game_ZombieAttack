using System.Collections;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField] private float _destroyTime;

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_destroyTime);
        PoolManager.instance.ReturnObject(this.gameObject);
    }
}
