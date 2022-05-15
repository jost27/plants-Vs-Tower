using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ControlManager : MonoBehaviour
{
    public UnityEvent startGame, pauseGame;

    GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.OnPauseGame -= pause;
        gameManager.OnPauseGame += pause;
        gameManager.OnStartGame -= Begingame;
        gameManager.OnStartGame += Begingame;
        
    }
    void Begingame()
    {
        startGame.Invoke();
    }
    void pause()
    {
        pauseGame.Invoke();

    }

}
