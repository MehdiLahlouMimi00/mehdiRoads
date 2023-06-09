using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoop : MonoBehaviour
{
    public static bool isActive;


    private void Awake()
    {
       isActive = false;
    }

    void Update()
    {
        if (isActive)
        {
            

            if (!GameObject.FindWithTag("Player").activeSelf)
            {
                GameObject.FindWithTag("Player").SetActive(true);

            }
        }
    }
}
