using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Objeto del menu
    public GameObject menu;

    // ImageTarget
    public GameObject imageTarget;

    // Interfaz
    public GameObject uiPanel;

    // Instrucciones
    public GameObject instructionPanel1;
    public GameObject instructionPanel2;


    // Método para abrir el menú
    public void OpenMenu()
    {
        Activate(true, false);
    }

    // Método para cerrar el menú
    public void CloseMenu()
    {
        Activate(false, true);
    }

    // Método para cambiar de receta
    public void ChangeRecipe()
    {
        SceneManager.LoadScene("Nivel 1 Menu");
    }

    // Método para salir de la aplicación
    public void Close()
    {
        Application.Quit();
    }

    // Cosas de las instrucciones
    public void ShowInstructions1()
    {
        imageTarget.SetActive(false);
        uiPanel.SetActive(false);
        instructionPanel1.SetActive(true);
    }
    public void ShowInstructions2()
    {
        instructionPanel1.SetActive(false);
        instructionPanel2.SetActive(true);
    }
    public void CloseInstructions()
    {
        instructionPanel2.SetActive(false);
        imageTarget.SetActive(true);
        uiPanel.SetActive(true);
    }

    // Método de algo
    void Activate(bool a, bool b)
    {
        menu.SetActive(a);
        imageTarget.SetActive(b);
        uiPanel.SetActive(b);
    }
}
