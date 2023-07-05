using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LoseScreen : MonoBehaviour
{

    public TextMeshProUGUI score, hscore;

    public static LoseScreen Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SetUp()
    {
        score.text = RoadManager.Instance.LastTouched + "";
        hscore.text = "HS";
    }
}
