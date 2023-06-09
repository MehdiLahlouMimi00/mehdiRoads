
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public List<GameObject> PossibleRoads;
    public Transform sheep;

    public Vector3 startingPosition;
    public float threshold;

    private int generatedRoads;
    private float lastPositionGenerated;



    private void Start()
    {
        lastPositionGenerated = -4f;
    }

    void FixedUpdate()
    {
        if (MainLoop.isActive)
        {
            if (Mathf.Abs(Controller.score - generatedRoads) <= threshold)
                GenerateRoad();
        }
        // Loop to destroy the roads that are not here 

    }



    private void GenerateRoad()
    {
        int len = PossibleRoads.Count;
        int random = (int)Random.Range(0, len);

        GameObject generatedRoad = Instantiate(PossibleRoads[random], new Vector3(lastPositionGenerated - (generatedRoads+1)*3f, -1.9f, -2.4f), Quaternion.identity);
        generatedRoad.transform.SetParent(GameObject.FindWithTag("Platforms").transform);    // So it will be well structured

        generatedRoads++;
    }



}
