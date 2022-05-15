using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static  ObjectPooling SharedInstance;
    public List<GameObject> pooledObjects;
    [SerializeField] Transform misilparent;
    public GameObject objectToPool;
    public int amountToPool;

    private void Awake()
    {
        SharedInstance= this;
    }
    private void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject pivot;
        for(int i=0;i < amountToPool; i++)
        {
            pivot = Instantiate(objectToPool);
            pivot.transform.SetParent(misilparent);
            pivot.SetActive(false);
            pooledObjects.Add(pivot);
        }
    }
   

    public GameObject GetPooledObject()
    {
        for(int i=0; i<amountToPool;i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
