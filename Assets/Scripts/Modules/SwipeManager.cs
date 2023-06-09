using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{

    public static bool[] directions;

    private Vector2 startTouch, endTouch,swipeDelta;
    public static float minScrollDistance = 0.1f;

    public float limit = 10;

    public float angle;

    private Vector2 axisX = new Vector2(1, 0);

    /*
    Quick documentation for myself lol !
    - It is an array of length 5,
    - 0 : left, 1 : right, 2 : up, 3 : down
    - The true is moving in the corresponding direction.
    - The false is its not moving.
     */

    private void Awake()
    {
        directions = new bool[4] { false, false, false, false };
    }


    private void FixedUpdate()
    {
        

        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (Input.touches[0].phase == TouchPhase.Began)
            {
                startTouch = touch.position;

            }



            else if (Input.touches[0].phase == TouchPhase.Ended)
            {
                endTouch = touch.position;

                swipeDelta = endTouch - startTouch;

                if (swipeDelta.magnitude > minScrollDistance)
                {
                    angle = Vector2.Angle(swipeDelta, axisX);

                    if (Mathf.Abs(angle) < limit) // right
                        directions[1] = true;

                    else if (angle > limit && angle < 180 - limit)  // up
                        directions[2] = true;

                    else if (angle > 180 - limit && angle < 180 + limit)   // left
                        directions[0] = true;

                    else
                        directions[3] = true;


                }

            }

        }

    }

    private void LateUpdate()
    {
        directions = new bool[4] { false, false, false, false };
    }
}
