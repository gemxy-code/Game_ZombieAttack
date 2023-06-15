using System.Collections;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    [SerializeField] private EnemyData[] _enemiesDatas;
    [SerializeField] private PooledItemData[] _datas;

    private int _accumulatedWeight;
    private float _spawnTime = 2f;
    private float _minSpawnTime = 0.5f;
    private float _timeDifference = 0.1f;
    private System.Random _rand = new System.Random();

    private void Start()
    {
        CalculateWeight();
        StartCoroutine(SpawnNewEnemy());
    }

    //Coroutine for spawn zombie
    private IEnumerator SpawnNewEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTime);
            int randomZombie = RandomZombie();
            PoolManager.instance.RentObject(_datas[randomZombie].Prefab);
            if (_spawnTime > _minSpawnTime)
                _spawnTime -= _timeDifference;
        }
    }

    private int RandomZombie()
    {
        double r = _rand.NextDouble() * _accumulatedWeight;
        for (int i = 0; i < _enemiesDatas.Length; i++)
        {
            if (_enemiesDatas[i]._weight >= r)
                return i;
        }
        return 0;
    }

    private void CalculateWeight()
    {
        _accumulatedWeight = 0;
        foreach(EnemyData enemy in _enemiesDatas)
        {
            _accumulatedWeight += enemy.Chance;
            enemy._weight = _accumulatedWeight;
        }
    }
}
