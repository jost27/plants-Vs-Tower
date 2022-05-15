using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Enemy Generator")]
    EnemyGenerator enemyGenerator;
    [SerializeField] int totalZombies;

    [Header("UI Control")]

    [SerializeField] GameObject PanelLose;
    [SerializeField] GameObject PanelWin;

    [Header("Shop system")]
    [SerializeField] int initialConins=600;
    // shop sysyem
    ShopTowers shop;
    // State of game
    public delegate void PauseGame();
    public event PauseGame OnPauseGame;
    public delegate void StartGame();
    public event StartGame OnStartGame;

    bool _startGame;

    private void Start()
    {
        // zombie generator
        enemyGenerator = FindObjectOfType<EnemyGenerator>();
        enemyGenerator.enemyInstances = totalZombies;
        // shop
        shop = FindObjectOfType<ShopTowers>();
        shop.PlayerSunCoins = initialConins;

    }

    public void UpdateZombies()
    {
        totalZombies--;
        if (totalZombies <= 0)
            WinAction();
    }
    public void LoseAction()
    {
        PanelLose.SetActive(true);
    }

    public void WinAction()
    {

        PanelWin.SetActive(true);

    }

    public void ReloadScene()
    {
        Scene sceneLoaded = SceneManager.GetActiveScene();
        // reload
        SceneManager.LoadScene(sceneLoaded.buildIndex );
    }


    public void SetStateGame(bool stategame)
    {
        _startGame = stategame;
        StateGame();
    }
    
    public void StateGame()
    {
        if (_startGame)
            OnStartGame();
        else
            OnPauseGame();
    }
   
}
