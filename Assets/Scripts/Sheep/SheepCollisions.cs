using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Road"))
        {
            if (!collision.gameObject.GetComponent<RoadBehavior>().isVisited)
            {
                RoadManager.Instance.LastTouched++;
                collision.gameObject.GetComponent<RoadBehavior>().isVisited = true;
            }
        }
        if (collision.transform.CompareTag("Car"))
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Lose);
        }

        if (collision.transform.CompareTag("Tree"))
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

    }
}
