using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] private float _zombieSpeed;
    [SerializeField] private float _health;
    [SerializeField] private int _score;

    private GameObject _target;
    private bool isDead = false;
    private Vector3 _targetDir;

    void Start()
    {
        _target = GameObject.FindWithTag("Player");
    }


    //Zombie take damage
    public void TakeDamage()
    {
        if (_health > 1f)
        {
            _health -= 1f;
        }
        else if (!isDead)
        {
            _health -= 1f;
            Dead();
        }
    }

    //Zombie dead
    private void Dead()
    {      
        CountScore.score += _score;
        isDead = true;
        Destroy(gameObject);
    }

    //hit player
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == _target)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    //Zombie movement 
    void LateUpdate()
    {
        _targetDir = new Vector3 (_target.transform.position.x - transform.position.x, 0, _target.transform.position.z  -  transform.position.z);
        transform.LookAt(new Vector3 (_target.transform.position.x, 0f, _target.transform.position.z));
        transform.position += _targetDir.normalized * _zombieSpeed * Time.deltaTime;
    }
}
