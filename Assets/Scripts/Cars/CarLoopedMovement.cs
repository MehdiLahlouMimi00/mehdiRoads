using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarLoopedMovement : MonoBehaviour
{
    public Rigidbody rb;
    public bool running;
    public float duration;

    private void OnEnable()
    {
        running = false;
    }


    private void Update()
    {
        
        if (this.gameObject.activeInHierarchy)
        {
            if (rb.velocity.magnitude > 0.01)
                running = true;

            else
                running = false;

            if (!running && transform.position.z <= -5f)
            {
                rb.DOMoveZ(5.01f, duration, false);
            }

            else if (!running && transform.position.z >= 5f)
            {
                rb.DOMoveZ(-5.01f, duration, false);
            }
        }
    }





}
