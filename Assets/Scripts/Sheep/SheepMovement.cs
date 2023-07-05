using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SheepMovement : MonoBehaviour
{
    public static float translationDistance= 2f;

    private Vector2 startPos;
    public float scrollMin = 20f;
    private bool FingerDown;

    public Transform comera;

    public Rigidbody sheepBody;


    private Vector2 fingerDown;
    private Vector2 fingerUp;

    public float range;

    private float a, b;

    public float cooldown;
    private float timer;


    private void Start()
    {
        timer = cooldown;
        a = range * (Mathf.PI/180);
        b = Mathf.Cos(a);
    }

    private void Update()
    {

        timer -= Time.deltaTime;

        if (Input.touchCount > 0 && MainLoop.isActive)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                fingerDown = touch.position;
                fingerUp = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerUp = touch.position;

                string direction = DetectPosition(fingerUp, fingerDown);

                if (direction == "r")
                {
                    sheepBody.DOMoveZ(transform.position.z - translationDistance, 0.5f, false);
                    CameraManager.Instance.CameraRight();

                }
                else if (direction == "u")
                {
                    sheepBody.DOMoveX(transform.position.x + translationDistance, 0.5f, false);
                    CameraManager.Instance.CameraForward();

                }

                else if (direction == "l")
                {
                    sheepBody.DOMoveZ(transform.position.z + translationDistance, 0.5f, false);
                    CameraManager.Instance.CameraLeft();

                }
                else if (direction == "d")
                {
                    sheepBody.DOMoveX(transform.position.x - translationDistance, 0.5f, false);
                    CameraManager.Instance.CameraDown();

                }

            }

        }

    }

    private string DetectPosition(Vector2 up, Vector2 down)
    {
        Vector2 delta = up - down;
        float cost = Vector2.Dot(delta.normalized, Vector2.right); 


        if (delta.magnitude > scrollMin)
        {
            if (cost >= b)
                return "r";
           
            else if (cost <= -b)
                return "l";
           
            else
            {
                if (delta.y > 0)
                    return "u";
                else
                    return "d";
            }
                
        }

        else
        {
            return "";
        }
    }

}
