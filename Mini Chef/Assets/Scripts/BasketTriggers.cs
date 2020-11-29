using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketTriggers : MonoBehaviour
{
    // Referencia a todas las variables
    GameVariables gameVariables;

    // GameObject Text
    public GameObject text;

    // Pantalla de resultados
    public GameObject resultScreen;

    // Timer
    public Text timer;
    float time;

    // Números de si o no
    public Text correctText;
    public Text incorrectText;
    float textTime;

    // Start
    private void Start()
    {
        // Se hace referencia al script que contiene las variables del juego
        gameVariables = GameObject.Find("GameVariables").GetComponent<GameVariables>();
        time = 120;
    }

    // Update
    private void Update()
    {
        // TODO PARA EL TEMPORIZADOR!!!
        time -= Time.deltaTime;
        textTime -= Time.deltaTime;
        timer.text = time.ToString("f0");

        if (time < 0)
        {
            resultScreen.GetComponent<ResultScreen>().ShowResult();
        }
        if(textTime < 0)
        {
            correctText.text = " ";
            incorrectText.text = " ";
        }
    }

    // Método cuando se acerca a una canasta
    private void OnTriggerEnter(Collider other)
    {
        other.transform.localScale += new Vector3(.5f, .5f, .5f);
        //text.GetComponent<Text>().text = "Está en la cesta";
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonUp(0))
        {
            switch(other.tag)
            {
                case "Needed":
                    gameVariables.points += 100;
                    text.GetComponent<Text>().text = "Puntos: " + gameVariables.points.ToString();
                    gameVariables.ingredientsCount--;
                    other.gameObject.SetActive(false);
                    correctText.text = " ";
                    incorrectText.text = " ";
                    correctText.text = "+100";
                    textTime = 2f;
                    break;
                case "Optional":
                    gameVariables.points += 50;
                    text.GetComponent<Text>().text = "Puntos: " + gameVariables.points.ToString();
                    gameVariables.ingredientsCount--;
                    other.gameObject.SetActive(false);
                    correctText.text = " ";
                    incorrectText.text = " ";
                    correctText.text = "+50";
                    textTime = 2f;
                    break;
                case "Wrong":
                    gameVariables.points -= 25;
                    text.GetComponent<Text>().text = "Puntos: " + gameVariables.points.ToString();
                    correctText.text = " ";
                    incorrectText.text = " ";
                    incorrectText.text = "-25";
                    textTime = 2f;
                    break;
                default:
                    text.GetComponent<Text>().text = "Hubo algo siniestro";
                    break;
            }

            // Checando si terminar el juego
            if(gameVariables.ingredientsCount == 0)
            {
                resultScreen.GetComponent<ResultScreen>().ShowResult();
            }
        }
    }

    // Método cuando algo sale de la canasta
    private void OnTriggerExit(Collider other)
    {
        other.transform.localScale -= new Vector3(.5f, .5f, .5f);
        //text.GetComponent<Text>().text = "Salió de la cesta";
    }
}
