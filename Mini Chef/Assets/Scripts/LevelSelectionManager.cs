using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionManager : MonoBehaviour
{
    // Script de las variables
    GameVariables gameVariables;

    // Start is called before the first frame update
    void Start()
    {
        // Orientación de la pantalla
        Screen.orientation = ScreenOrientation.Landscape;

        // Se hace referencia al script que contiene las variables del juego
        gameVariables = GameObject.Find("GameVariables").GetComponent<GameVariables>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Método que carga el nivel seleccionado
    public void LevelSelected(int selection)
    {
        // Selectiva del nivel
        switch(selection)
        {
            case 1:
                SceneManager.LoadScene("Nivel 1 Menu");
                break;
            case 2:
                SceneManager.LoadScene("Nivel 2 Menu");
                break;
            case 3:
                // Aún no hay nivel 3!!!
                break;
            default:
                // Nada
                break;
        }
    }
}
