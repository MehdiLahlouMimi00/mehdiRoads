using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private GameState State ;

    public GameObject overlay;
    public GameObject loseScreen;
    public GameObject menuUI;


    public enum GameState
    {
        Loading,
        MainMenu,
        InGame,
        Lose
    }

    private void Awake()
    {
        Instance = this;
        Instance.State = GameState.MainMenu;
        GameObject.FindWithTag("Menu UI").SetActive(true);
        GameObject.FindWithTag("Game Overlay").SetActive(false);
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

                menuUI.SetActive(true);
                break;


            case GameState.InGame:
                menuUI.SetActive(false);
                overlay.SetActive(true);
                CameraManager.Instance.StartingAnimation();
                MainLoop.isActive = true;
                loseScreen.SetActive(false);
                break;


            case GameState.Lose:
                loseScreen.SetActive(true);
                LoseScreen.Instance.SetUp();
                break;

            
        }

    }




}
