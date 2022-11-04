using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Open()
    {
        //Shows the menu
        gameObject.SetActive(true);


    }
    //A method that we want to hook up to when the restart button gets pressed
    public void Restart()
    {
        //Add code here to restart the game
        SceneManager.LoadScene(0);

    }

}
