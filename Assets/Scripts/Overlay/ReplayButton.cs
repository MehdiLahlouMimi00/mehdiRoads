using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayButton : MonoBehaviour
{
    public GameObject sheep;
    public GameObject startingPlatform;




    public void Replay()
    {
        foreach (GameObject road in RoadManager.Instance.RoadsNPlatforms)
        {
            road.transform.position = new Vector3(0f, 0f, 0f);
            road.GetComponent<RoadBehavior>().RerollBehavior();
        }


        RoadManager.Instance.RoadsNPlatforms.Insert(0, startingPlatform);
        RoadManager.Instance.ConcatenatePlatforms();

        sheep.transform.position = new Vector3(0f, 0.75f, 0f);
        GameManager.Instance.UpdateGameState(GameManager.GameState.InGame);


    }

}
