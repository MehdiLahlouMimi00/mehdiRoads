using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnARoad : MonoBehaviour
{
    public static void SpawnRoad()
    {
        GameObject road = RoadPool.Instance.GetPooledObject();
        if (road != null)
        {
            road.SetActive(true);
            RoadManager.Instance.ConcatenateLast();
        }
        
    }
}
