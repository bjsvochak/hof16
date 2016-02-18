using UnityEngine;
using System.Collections;

public class PooledObject : MonoBehaviour
{
    private ObjectPool objPool;

    public ObjectPool ObjectPool
    {
        get { return objPool; }
        set { objPool = value; }
    }
}
