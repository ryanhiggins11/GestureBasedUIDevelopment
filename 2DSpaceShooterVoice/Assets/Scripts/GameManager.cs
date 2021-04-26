
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Ryan Higgins
 * G00337350
 * Final Year Gesture Based UI Development Project
 * Controls the game scenes and also which scenes are loaded into the game next 
 */


public class GameManager : MonoBehaviour
{
    //Variables
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGO;
    public GameObject ScoreUITextGO;
    public GameObject TimeCounterGO;
    public GameObject GameTitleGO;
    public GameObject StartScreen;
    public GameObject ControlsScreen;
    public enum GameManagerState
    {
        opening,
        Gameplay,
        GameOver,
    }
    GameManagerState GMState;

    void Start()
    {
        GMState = GameManagerState.opening;
    }
    private void UpdateGameManagerStatus()
    {
        switch (GMState)
        {
            case GameManagerState.opening:
                playButton.SetActive(true);
                
                GameOverGO.SetActive(false);

                GameTitleGO.SetActive(true);
                break;
            case GameManagerState.Gameplay:
                ScoreUITextGO.GetComponent<GameScore>().Score = 0;

                playButton.SetActive(false);

                playerShip.GetComponent<PlayerMovement>().init();

                GameTitleGO.SetActive(false);

                enemySpawner.GetComponent<EnemySpawner>().SchedueleEnemySpawner();

                TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter();
                break;
            case GameManagerState.GameOver:
                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();
                GameTitleGO.SetActive(false);
                enemySpawner.GetComponent<EnemySpawner>().UnschedueleEnemySpawner();
                Invoke("changeToOpeningState", 4f);
                GameOverGO.SetActive(true);
                break;
        }
    }

    public void setGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerStatus();
    }

    public void StartGameManager()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerStatus();
    }
    public void changeToOpeningState()
    {
        setGameManagerState(GameManagerState.opening);
    }
}