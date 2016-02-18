using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> availObjects;

    public void Awake()
    {
        availObjects = new List<GameObject>();
    }

    public GameObject GetObject()
    {
        if (availObjects.Count == 0)
        {
            GameObject newObject = Instantiate(prefab);
            newObject.GetComponent<PooledObject>().ObjectPool = this;
            newObject.transform.SetParent(transform);
            return newObject;
        }

        GameObject gameObject = availObjects[0];
        gameObject.SetActive(true);
        availObjects.RemoveAt(0);
        return gameObject;        
    }

    public void ReturnObject(GameObject _object)
    {
        _object.SetActive(false);
        availObjects.Add(_object);
    }
}
