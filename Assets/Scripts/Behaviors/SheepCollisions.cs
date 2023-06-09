using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepCollisions : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Car":
                GameManager.Instance.UpdateGameState(GameManager.GameState.Lose);
                break;

            case "Road":
                Controller.score++;
                break;
        }
    }
}
