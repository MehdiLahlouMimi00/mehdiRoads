using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAnimation : MonoBehaviour
{
    public static void Call()
    {

        Debug.Log("The animation was called");
        GameManager.Instance.UpdateGameState(GameManager.GameState.MainMenu);
    }
}
