using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogtexte : MonoBehaviour
{
   
    public void movegame()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
     }
      
    
   
}
