using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private Factory _factory;
    [SerializeField] private PooledItemData[] _datas;

    private Dictionary<string, Queue<GameObject>> pools;

    public static PoolManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Init();
        }       
        else
            Destroy(this.gameObject);
    }

    private void Init()
    {
        pools = new Dictionary<string, Queue<GameObject>>();
        foreach (var item in _datas)
        {
            GameObject emptyObj = new GameObject(item.Name + " Pool");
            emptyObj.transform.parent = transform;

            Queue<GameObject> queue = new Queue<GameObject>();
            pools.Add(item.Name, queue);
            for(int i = 0; i < item.PoolCount; i++)
            {
                CreateNewObject(item.Prefab);
            }
        }
    }

    private GameObject CreateNewObject(GameObject Object)
    {
        GameObject newObject = _factory.GetProduct(Object);
        newObject.transform.parent = GameObject.Find(Object.name + " Pool").transform;
        pools[Object.name].Enqueue( newObject );
        newObject.SetActive(false);
        return newObject;
    }

    public GameObject RentObject(GameObject Object)
    {
        GameObject rentedObject;
        if (pools[Object.name].Count > 0)
        {
            rentedObject = pools[Object.name].Dequeue();
            rentedObject.SetActive(true);
        }
        else
        {
           rentedObject = CreateNewObject(Object);
        }
        return rentedObject;
    }


    public void ReturnObject(GameObject Object)
    {
        Object.SetActive(false);
        pools[Object.name].Enqueue(Object);
    }
}
