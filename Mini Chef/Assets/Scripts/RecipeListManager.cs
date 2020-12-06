using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecipeListManager : MonoBehaviour
{
    // Script de las variables
    GameVariables gameVariables;

    // Start is called before the first frame update
    void Start()
    {
        // Orientación de la pantalla
        Screen.orientation = ScreenOrientation.Portrait;

        // Se hace referencia al script que contiene las variables del juego
        gameVariables = GameObject.Find("GameVariables").GetComponent<GameVariables>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Método para asignar una receta al juego
    public void SetRecipe(int selection)
    {
        gameVariables.recipe = selection;
        SceneManager.LoadScene("LevelSelection");
    }
}
