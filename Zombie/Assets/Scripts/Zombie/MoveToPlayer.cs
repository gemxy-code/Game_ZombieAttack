using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;

    private GameObject _target;
    private Vector3 _targetDir;

    private void Awake()
    {
        _target = GameObject.FindObjectOfType<PlayerRotate>().gameObject;
    }

    void Update()
    {
        _targetDir = new Vector3(_target.transform.position.x - transform.position.x, 0, _target.transform.position.z - transform.position.z);
        transform.LookAt(new Vector3(_target.transform.position.x, 0f, _target.transform.position.z));
        transform.position += _targetDir.normalized * _enemyData.ZombieSpeed * Time.deltaTime;
    }

}
