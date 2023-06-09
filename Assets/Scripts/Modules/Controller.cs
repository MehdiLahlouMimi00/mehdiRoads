using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static int score = 0;


    public float cooldown = 0.5f;
    private float lastMoveTime = 0f;

    public float Speed;

    public Vector2 touchDelta;

    public Rigidbody rb;
    public float force;

    public bool[] debutNemm;

    public Vector3 porteuse;

    private Quaternion rotation = Quaternion.AngleAxis(90f, new Vector3(0, 1, 0));
    private Quaternion inRotation = Quaternion.AngleAxis(-90f, new Vector3(0, 1, 0));

    public Vector3 directed;


    private void Move(Vector3 porteuse_, float force_, float Speed_)
    {
        

        transform.Translate(porteuse);


        lastMoveTime = Time.time;

    }

    private void Awake()
    {
        porteuse = new Vector3(-1, 0, 0);
        this.gameObject.SetActive(true);
        
    }


    void Update()
    {
        debutNemm = SwipeManager.directions;
       
        float timeSinceLastMove = Time.time - lastMoveTime;


        #region swiping
        if (Input.touches.Length > 0 && timeSinceLastMove >= cooldown)
        {
            if (SwipeManager.directions[0])
            {
                transform.rotation *= inRotation;
                porteuse = inRotation * porteuse;
                Move(porteuse, force, Speed);
            }
            else if (SwipeManager.directions[1])
            {
                transform.rotation *= rotation;
                porteuse = rotation * porteuse;
                Move(porteuse, force, Speed);
            }

            else if (SwipeManager.directions[3])
            {
                porteuse *= -1;
                Move(porteuse, force, Speed);

            }

            else if (SwipeManager.directions[2])
            {
                Move(porteuse, force, Speed);

            }

        }

        #endregion 
        

    }
}

