using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public bool isOver;
    //public bool retry;
    public GameObject GameOverMenu;

    // Update is called once per frame
    void Update()
    {
        if (isOver)
        {
            Time.timeScale = 0f;
            GameOverMenu.SetActive(true);
        }
        else
        {
            //retry = false;
            Time.timeScale = 1f;
            GameOverMenu.SetActive(false);
        }

    }
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
        isOver = !isOver;
        //retry = !retry;
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

}