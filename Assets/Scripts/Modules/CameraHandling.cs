using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandling : MonoBehaviour
{
    public float timeSpeed;

    public float step;

    private Vector3 up = new Vector3(0f, 1f, 0f);

    void Update()
    {
        Vector3 direction, targetPosition;

        direction = Vector3.zero;
        if (SwipeManager.directions[2])
            direction = up;

        else if (SwipeManager.directions[3])
            direction = -up;

        targetPosition = direction * step + transform.position;

        transform.position = Vector3.Slerp(transform.position, targetPosition, timeSpeed* Time.time) ;
        
    }
}
