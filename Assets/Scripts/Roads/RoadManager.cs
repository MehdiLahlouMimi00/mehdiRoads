using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoadManager : MonoBehaviour
{
    public List<GameObject> RoadsNPlatforms;
    public GameObject startingPlatform;

    public int LastTouched = 0;     // Index of the road lastly visited by the sheep


    public static RoadManager Instance;

    private bool extended;

    private void Awake()
    {
        RoadsNPlatforms.Insert(0, startingPlatform);

        if (Instance == null)
            Instance = this;

        extended = false;
    }




    

    public void ConcatenateLast()
    {
        /*
         * This function is made to put the last road on the list in the right position
         * After adding the trees and the cars I should cancel the behavior and move everything with them
         */
        int n = RoadsNPlatforms.Count;

        float x_i = RoadsNPlatforms[n - 2].transform.position.x;
        float s_i = RoadsNPlatforms[n - 2].transform.localScale.x;
        float s_j = RoadsNPlatforms[n - 1].transform.localScale.x;

        float x_j = x_i + (s_i + s_j) / 2;

        RoadsNPlatforms[n-1].transform.Translate(Vector3.right * (x_j));

        RoadsNPlatforms[n - 1].GetComponent<RoadBehavior>().RerollBehavior();
        RoadsNPlatforms[n - 1].GetComponent<RoadBehavior>().PlaceTrees();
        RoadsNPlatforms[n - 1].GetComponent<RoadBehavior>().associatedCar.transform.position = new Vector3(
                x_j,
                2f,
                5.01f
                );


    }

    public void ConcatenatePlatforms()
    {

        /*
         * This function serves only in the beginning, it is used to put them at their place after they were at 0
         */


        int n = RoadsNPlatforms.Count;

        for (int i = 1; i < n; i++)
        {
            float x_i = RoadsNPlatforms[i - 1].transform.position.x;
            float s_i = RoadsNPlatforms[i - 1].transform.localScale.x;
            float s_j = RoadsNPlatforms[i].transform.localScale.x;

            float x_j = x_i + (s_i + s_j) / 2;

            RoadsNPlatforms[i].transform.Translate(Vector3.right * (x_j));
            RoadsNPlatforms[i].GetComponent<RoadBehavior>().associatedCar.transform.position = new Vector3(
                x_j,
                2f,
                5.01f
                );

            RoadsNPlatforms[i].GetComponent<RoadBehavior>().PlaceTrees();
        }

    }


    public void ConcatenateBeginner()
    {

        /*
         * It is to move the last platform to the front to make the game look endless 
         */

        GameObject LastItem = RoadsNPlatforms[0];
        RoadsNPlatforms.RemoveAt(0);
        RoadsNPlatforms.Add(LastItem);

        RoadsNPlatforms.Last().transform.position = Vector3.zero;



        ConcatenateLast();
    }



    private void Start()
    {
        ConcatenatePlatforms();
        RoadsNPlatforms.RemoveAt(0);     // To remove the platform but we can still see it on the game ;)
    }


    // So we can make it infinite
    private void Update()
    {

        if (LastTouched >= 0)
        {
            SheepMovement.translationDistance = 2.45f;
        }

        if (LastTouched > 3 )
        {
            if (LastTouched %3 == 1)
            {
                if (!extended)
                {
                    ConcatenateBeginner();
                    ConcatenateBeginner();
                    ConcatenateBeginner();

                    extended = true;

                }
            }

            else
            {
                extended = false;
            }
        }

        
    }


}
