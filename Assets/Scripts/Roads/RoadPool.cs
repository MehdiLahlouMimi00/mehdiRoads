using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPool : MonoBehaviour
{
    public static RoadPool Instance;


    public GameObject Prefab;
    public List<GameObject> PooledObjects;

    public int AmountToPool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    private void Start()
    {
        for (int i = 0; i < AmountToPool; i++)
        {
            GameObject obj = Instantiate(Prefab, new Vector3(0,0,0), Quaternion.identity);
            PooledObjects.Add(obj);
            obj.SetActive(false);
        }
    }




    public GameObject GetPooledObject()
    {

        for (int i = 0; i < PooledObjects.Count; i++)
        {
            if (!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }

        return null;

    }



}
