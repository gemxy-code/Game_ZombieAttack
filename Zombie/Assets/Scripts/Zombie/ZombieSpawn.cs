using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] _zombies;

    private float[,] xPoints;
    private float _timeSpawn;
    private float _timeUpdate = 10f;
    
    void Start()
    {
        _timeSpawn = 2f;
        _timeUpdate = 10f; // timer for update

        //zombie spawn points for different resolutions
        if (Camera.main.aspect >= 1.7f)
        {
            xPoints = new float[3, 2] { { -16f, -16.5f }, { 16f, 16.5f }, { -11f, 11f } };
        }
        else if (Camera.main.aspect >= 1.3)
        {
            xPoints = new float[3, 2] { { -12.5f, -13f }, { 12.5f, 13f }, { -8f, 8f } };
        }

        InvokeRepeating("CreateNewZombie", _timeSpawn, _timeSpawn);
    }

    void Update()
    {
        //update spawn time
        if (_timeUpdate <= 0f && _timeSpawn > 0.5f)
        {
            _timeSpawn -= 0.1f;
            _timeUpdate = 10f;
        }
        else
        {
            _timeUpdate -= Time.deltaTime;
        }
    }

    //new zombie 
    private void CreateNewZombie()
    {
        Vector3 randomPosition = CalculateZombiePosition();

        float randomZombie = Random.Range(10f, 100f);
        int resultZombie = randomZombie >= 90 && randomZombie <= 100 ? 2 : randomZombie >= 70 ? 1 : 0;

        Instantiate(_zombies[resultZombie], randomPosition, Quaternion.identity);
    }

    private Vector3 CalculateZombiePosition()
    {
        int place = Random.Range(0, 3);

        switch (place)
        {
            case 0:
                return (new Vector3(Random.Range(xPoints[place, 0], xPoints[place, 1]), 0f, Random.Range(1f, 6f)));
            case 1:
                return (new Vector3(Random.Range(xPoints[place, 0], xPoints[place, 1]), 0f, Random.Range(1f, 6f)));
            case 2:
            default:
                return (new Vector3(Random.Range(xPoints[place, 0], xPoints[place, 1]), 0f, Random.Range(10.5f, 11f)));
        }
    }
}
