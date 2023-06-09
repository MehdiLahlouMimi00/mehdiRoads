using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsRunning : MonoBehaviour
{

    private Rigidbody CarRb;
    
    public float endPos, startPos;

    public float proba;
    public float speed;

    public float cooldown;
    private float startTime;

    private void Awake()
    {
        CarRb = gameObject.GetComponent<Rigidbody>();
        startTime = Time.time; 
    }


    private void Update()
    {

        float z = Random.Range(0f, 1f);


        if (Time.time - startTime >= cooldown)
        {
            if (z > proba)
            {

                int direction = Random.Range(0, 2);

                switch (direction)
                {
                    case 0:
                        transform.position = new Vector3(transform.position.x, transform.position.y, endPos);
                        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -transform.localScale.z);
                        CarRb.velocity = new Vector3(0f, 0f, speed);
                        break;

                    case 1:
                        transform.position = new Vector3(transform.position.x, transform.position.y, startPos);

                        CarRb.velocity = new Vector3(0f, 0f, -speed);
                        break;
                }


            }

            startTime = Time.time;
        }
       
    }

}


