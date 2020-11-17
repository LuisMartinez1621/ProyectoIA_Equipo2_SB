using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Objeto del menu
    public GameObject menu;

    // Botón de pausa
    public GameObject pauseButton;

    // Texto en pantalla
    public GameObject infoBox;

    // ImageTarget
    public GameObject imageTarget;

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

    // Método de algo
    void Activate(bool a, bool b)
    {
        menu.SetActive(a);
        pauseButton.SetActive(b);
        infoBox.SetActive(b);
        imageTarget.SetActive(b);
    }
}
