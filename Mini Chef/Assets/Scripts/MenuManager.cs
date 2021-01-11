using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Pantallas
    GameObject login;
    GameObject register;

    // Varaibles
    GameObject backScreen;
    GameObject currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Cosa para guardar la pantalla anterior
    public void SetBackScreen(GameObject screen)
    {
        backScreen = screen;
    }

    public void SetCurrentScreen(GameObject screen)
    {
        currentScreen = screen;

        backScreen.SetActive(false);
        currentScreen.SetActive(true);
    }
}
