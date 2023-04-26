using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] private float _zombieSpeed;
    [SerializeField] private float _health;
    [SerializeField] private int _score;

    private GameObject _target;
    private Vector3 _targetDir;

    void Start()
    {
        _target = GameObject.FindWithTag("Player");
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
        CountScore.score += _score;
        Destroy(gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == _target)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    void LateUpdate()
    {
        _targetDir = new Vector3 (_target.transform.position.x - transform.position.x, 0, _target.transform.position.z  -  transform.position.z);
        transform.LookAt(new Vector3 (_target.transform.position.x, 0f, _target.transform.position.z));
        transform.position += _targetDir.normalized * _zombieSpeed * Time.deltaTime;
    }
}
