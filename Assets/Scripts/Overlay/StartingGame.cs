using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingGame : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.InGame);
    }
}
