using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1MenuManager : MonoBehaviour
{
    // Script de las variables
    GameVariables gameVariables;

    // Start is called before the first frame update
    void Start()
    {
        // Se hace referencia al script que contiene las variables del juego
        gameVariables = GameObject.Find("GameVariables").GetComponent<GameVariables>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Elección del primer nivel
    public void SetLevel1Recipe(int recipe)
    {
        // Se establece la receta
        gameVariables.level1Recipe = recipe;

        // Se inicia el nivel
        SceneManager.LoadScene("Nivel 1");
    }
}
