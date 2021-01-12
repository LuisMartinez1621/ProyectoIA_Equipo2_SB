using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Pantallas
    public GameObject start;
    public GameObject login;
    public GameObject register;
    public GameObject play;
    public GameObject kidRegister;
    public GameObject admin;
    public GameObject fatherRegister;
    public GameObject config;
    public GameObject hist;

    // Otras cosas
    public GameObject music;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 1 Pantalla del login
    public void ShowLogin(int s)
    {
        login.SetActive(true);
        DissableScreen(s);
    }

    // 2 Pantalla del registro
    public void ShowRegister(int s)
    {
        register.SetActive(true);
        DissableScreen(s);
    }

    // 3 Pantalla de jugar
    public void ShowPlay(int s)
    {
        play.SetActive(true);
        DissableScreen(s);
    }

    // 4 Pantalla del registro del niño
    public void ShowKidRegister(int s)
    {
        kidRegister.SetActive(true);
        DissableScreen(s);
    }

    // 5 Pantalla del registro del niño
    public void ShowAdmin(int s)
    {
        admin.SetActive(true);
        DissableScreen(s);
    }

    // 6 Pantalla del registro del niño
    public void ShowFatherRegister(int s)
    {
        fatherRegister.SetActive(true);
        DissableScreen(s);
    }

    // 7 Pantalla del registro del niño
    public void ShowConfig(int s)
    {
        config.SetActive(true);
        DissableScreen(s);
    }

    // 8 Pantalla del registro del niño
    public void ShowHist(int s)
    {
        hist.SetActive(true);
        DissableScreen(s);
    }

    // Iniciar juego
    public void StartGame()
    {
        SceneManager.LoadScene("RecipeList");
    }

    public void DissableScreen(int screen)
    {
        switch(screen)
        {
            case 0:
                start.SetActive(false);
                break;
            case 1:
                login.SetActive(false);
                break;
            case 2:
                register.SetActive(false);
                break;
            case 3:
                play.SetActive(false);
                break;
            case 4:
                kidRegister.SetActive(false);
                break;
            case 5:
                admin.SetActive(false);
                break;
            case 6:
                fatherRegister.SetActive(false);
                break;
            case 7:
                config.SetActive(false);
                break;
            case 8:
                hist.SetActive(false);
                break;
            default:
                break;
        }
    }

    // Cosas de la música
    public void SetMusic(bool v)
    {
        music.SetActive(v);
    }
}
