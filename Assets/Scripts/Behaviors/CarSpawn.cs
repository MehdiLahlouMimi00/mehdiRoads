using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{



    public GameObject Car;
    public float StartPos, EndPos;

    public float cooldownTime;

    private Rigidbody CarRb;

    public float speed;

    public float proba;


    private void Start()
    {

        GameObject CarInstance = Instantiate(Car);

        CarInstance.transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, StartPos);



        CarRb = CarInstance.GetComponent<Rigidbody>();

    }
}
