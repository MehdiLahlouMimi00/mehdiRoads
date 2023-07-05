using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBehavior : MonoBehaviour
{
    private bool CarBehavior;        // true if with a car false if with trees
    public GameObject associatedCar;

    public bool isVisited = false;

    public GameObject treePrefab;
    public List<GameObject> treesList;
    

    private void OnEnable()
    {
        RerollBehavior();

        
    }


    public void PlaceTrees()
    {
        if (!CarBehavior)
        {
            List<float> Positions = new List<float>();
            int r = Random.Range(0, 4);

            for (int g = 0; g < r; g++)
            {
                float z = Random.Range(-5f, 5f);
                GameObject obj = Instantiate(treePrefab, new Vector3(transform.position.x, 1f, z), Quaternion.identity);
                treesList.Add(obj);
            }



        }
    }


    public bool getBehavior()
    {
        return CarBehavior;
    }

    public void setBehavior(bool ne)
    {
        CarBehavior = ne;    // C la merde
    }


    public void RerollBehavior()
    {

        isVisited = false;

        // Clear everything that exists 
        if (!CarBehavior)
        {
            foreach (GameObject g in treesList)
            {
                
                Destroy(g);
                
            }
        }

        else
        {
            associatedCar.SetActive(false);
        }


        float p = Random.Range(0f, 1f);
        
        if (p >0.4f)
        {
            setBehavior(false);
            
        }

        else
        {
            setBehavior(true);
        }
    }

    private void Update()
    {
        associatedCar.SetActive(CarBehavior);
    }









}
