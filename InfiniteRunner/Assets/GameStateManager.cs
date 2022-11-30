using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameStateManager : MonoBehaviour
{

    [SerializeField]
    private GameObject GameOverScreen;

    private static GameStateManager _instance;

    void Start()
    {
        if (_instance = this)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public static void GameOver()
    {
        //SceneManager.LoadScene("Menu");
        Time.timeScale = 0f;
        SceneManager.LoadScene("GameOverScene");
        gameOver.isOver = true;

    }

}
