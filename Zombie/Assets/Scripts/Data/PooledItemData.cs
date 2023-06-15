using UnityEngine;


[CreateAssetMenu (fileName = "new Pooled Item Data", menuName = "Scriptable Objects/Pooled Item", order = 51)]
public class PooledItemData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _poolCount;
    [SerializeField] private GameObject _prefab;

    public string Name { get => _name; private set => _name = value; }
    public GameObject Prefab { get => _prefab; private set => _prefab = value; }
    public int PoolCount { get => _poolCount; private set => _poolCount = value; }

}
