using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameispaused = false ;

    public GameObject PauseMenuUI;  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameispaused)
            {
                resume();
                
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        PauseMenuUI.SetActive(false );
        Time.timeScale = 1f;
        gameispaused = false;  
    }
    public void pause ()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameispaused = true; 
    }
}

