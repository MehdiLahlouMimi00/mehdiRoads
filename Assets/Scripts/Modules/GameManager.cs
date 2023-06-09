using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private GameState State = GameState.MainMenu;


    public enum GameState
    {
        Loading,
        MainMenu,
        InGame,
        Lose,
        Win
    }

    private void Awake()
    {
        Instance = this;
        //Instance.State = GameState.MainMenu;
        // GameObject.FindWithTag("Menu UI").SetActive(false);
    }


    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {

            case GameState.Loading:
                LoadingAnimation.Call();
                break;

            case GameState.MainMenu:

                GameObject.FindWithTag("Menu UI").SetActive(true);
                break;


            case GameState.InGame:
                GameObject.FindWithTag("Menu UI").SetActive(false);
                MainLoop.isActive = true;
                break;


            case GameState.Lose:
                GameObject.FindWithTag("Lose Sceen").SetActive(true);
                break;

            case GameState.Win:
                GameObject.FindWithTag("Win Sceen").SetActive(true);
                break;
        }

    }





    

    void Update()
    {
        
    }



}
