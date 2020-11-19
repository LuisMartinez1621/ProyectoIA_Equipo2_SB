﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameVariables : MonoBehaviour
{
    // Cosas
    public static GameVariables gameVariables;

    // Nivel1
    public int level1Recipe = 0;
    public int ingredientsCount = 0;

    // Puntos de un nivel
    public float points = 0;

    //Awakakake
    private void Awake()
    {
        if(gameVariables == null)
        {
            gameVariables = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(gameVariables != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
