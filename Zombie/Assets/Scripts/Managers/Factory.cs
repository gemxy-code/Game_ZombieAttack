using UnityEngine;

public class Factory : MonoBehaviour
{
    public GameObject GetProduct(GameObject obj)
    {
        GameObject newObject = Instantiate(obj);
        newObject.name = obj.name;
        return newObject;
    }
}
