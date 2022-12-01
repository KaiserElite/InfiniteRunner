using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    private void Open()
    {
        //Shows the menu
        gameObject.SetActive(true);


    }
   
    public void Restart()
    {
        //Add code here to restart the game
        SceneManager.LoadScene(0);

    }

}
