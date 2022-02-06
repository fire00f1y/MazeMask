using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    
    /**
     * 0: Playing
     * 1: Paused
     */
    public int state = 0;

    public void Awake()
    {
        if (instance != null)
        {
            //Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public static GameManager Instance()
    {
        return instance;
    }
    
    public void GameOver()
    {
        state = 1;
    }

    public void Restart()
    {
        state = 0;
        SceneManager.LoadScene(0);
    }
}
