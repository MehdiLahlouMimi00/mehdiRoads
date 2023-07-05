using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreDisplaying : MonoBehaviour
{

    public TextMeshProUGUI display;

    void Update()
    {
        display.text = RoadManager.Instance.LastTouched + "";
    }
}
