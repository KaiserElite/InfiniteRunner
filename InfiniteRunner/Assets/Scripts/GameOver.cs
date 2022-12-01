using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{
    public static bool isOver;
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
           
            Time.timeScale = 1f;
            GameOverMenu.SetActive(false);
        }

    }
    public void Retry()
    {
        Time.timeScale = 1f;
        isOver = !isOver;
        SceneManager.LoadScene("SampleScene");

    }
    public void Menu()
    {
        isOver = !isOver;
        SceneManager.LoadScene("Menu");

    }

}
