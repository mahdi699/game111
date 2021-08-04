using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class GameManager : MonoBehaviour
{

    public static int currentScore;
    public static int hightScore;

    public static int currentLevel;
    public static int unlockedLevel;

    private bool player1, player2;
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void completeLevel(bool player1, bool player2)
    {

        if (currentLevel < 4 && player1 && player2)
        {
            currentLevel += 4;
            Application.LoadLevel(currentLevel);
        }
       
        else
           if (currentLevel ==4  && player1 && player2)
        {
            currentLevel += 1;
            Application.LoadLevel(currentLevel);
        }

        else
        {
            Debug.Log("ggez");
        }
    }


    public void SetBool (int index, bool state) {
        if(index == 1) {
            player1 = state;
        } else {
            player2 = state;
        }
        completeLevel(player1, player2);
    }
}