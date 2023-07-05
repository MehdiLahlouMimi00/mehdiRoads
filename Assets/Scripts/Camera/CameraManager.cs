using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    


    public void CameraForward()
    {
        transform.DOMoveX( transform.position.x + SheepMovement.translationDistance, 1, false);
    }

    public void CameraLeft()
    {
        transform.DOMoveZ(transform.position.z + SheepMovement.translationDistance, 1, false);
    }

    public void CameraRight()
    {
        transform.DOMoveZ(transform.position.z - SheepMovement.translationDistance, 1, false);
    }

    public void CameraDown()
    {
        transform.DOMoveX(transform.position.x - SheepMovement.translationDistance, 1, false);
    }


    public void StartingAnimation()
    {
        transform.DORotate(new Vector3(90f,0f,-90f), 0.5f, RotateMode.Fast);
        transform.DOMove(new Vector3(0f , 8f, 0f), 1.5f, false);
    }



    


}
