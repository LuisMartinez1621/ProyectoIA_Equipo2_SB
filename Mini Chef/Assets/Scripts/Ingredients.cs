using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    // TODOS LOS INGREDIENTES!
    public GameObject agua;
    public GameObject arroz;
    public GameObject atun;
    public GameObject boteCrema;
    public GameObject boteMayonesa;
    public GameObject boteMostaza;
    public GameObject canela;
    public GameObject harina;
    public GameObject huevos;
    public GameObject jamon;
    public GameObject leche;
    public GameObject lechuga;
    public GameObject mantequilla;
    public GameObject miel;
    public GameObject pan;
    public GameObject pasas;
    public GameObject pimienta;
    public GameObject queso;
    public GameObject sal;
    public GameObject verdura;
    public GameObject nada;

    // Script de las variables
    GameVariables gameVariables;

    // Variable de la receta
    public int recipe;

    // Método que regresa un array
    public GameObject[] GetRecipe ()
    {
        // Se hace referencia al script que contiene las variables del juego
        gameVariables = GameObject.Find("GameVariables").GetComponent<GameVariables>();

        // Se establece la receta del nivel
        recipe = gameVariables.recipe;

        // Se crea el arreglo
        GameObject[] array;

        // Se crean la lista de ingredientes del nivel
        switch (recipe)
        {
            // Sandwich
            case 1:
                array = new GameObject[]
                {
                    // Debe llevar
                    jamon,
                    pan,
                    queso,
                    // Puede llevar
                    boteMayonesa,
                    boteMostaza,
                    lechuga,
                    // No lleva
                    harina,
                    leche,
                    miel
                };
                array = PutTags(array, 3, 3, 3);
                break;

            // Huev0s con jamón
            case 2:
                array = new GameObject[]
                {
                    // Debe llevar
                    huevos,
                    jamon,
                    leche,
                    mantequilla,
                    // Puede llevar
                    pimienta,
                    queso,
                    sal,
                    // No lleva
                    boteCrema,
                    lechuga
                };
                array = PutTags(array, 4, 3, 2);
                break;

            // Ensalada de atún
            case 3:
                array = new GameObject[]
                {
                    // Debe llevar
                    atun,
                    verdura,
                    // Puede llevar
                    boteCrema,
                    boteMayonesa,
                    pimienta,
                    sal,
                    // No lleva
                    pan,
                    harina,
                    miel
                };
                array = PutTags(array, 2, 4, 3);
                break;

            // Arroz con leshe
            case 4:
                array = new GameObject[]
                {
                    // Debe llevar
                    agua,
                    arroz,
                    leche,
                    // Puede llevar
                    canela,
                    pasas,
                    // No lleva
                    boteMostaza,
                    jamon,
                    pan,
                    queso

                };
                array = PutTags(array, 3, 2, 4);
                break;

            // Hot cakes
            case 5:
                array = new GameObject[]
                {
                    // Debe llevar
                    harina,
                    huevos,
                    leche,
                    // Puede llevar
                    mantequilla,
                    miel,
                    // No lleva
                    boteMayonesa,
                    pimienta,
                    pan,
                    lechuga
                };
                array = PutTags(array, 3, 2, 4);
                break;

            default:
                array = new GameObject[] { };
                break;
        }
        return array;
    }

    GameObject[] PutTags(GameObject[] array, int needed, int optional, int wrong)
    {
        int count = 0;
        for (int c = count; c < needed; c++)
        {
            array[c].transform.gameObject.tag = "Needed";
        }
        count = needed;
        for (int c = count; c < needed + optional; c++)
        {
            array[c].transform.gameObject.tag = "Optional";
        }
        count = needed + optional;
        for(int c = count; c < count + wrong; c++)
        {
            array[c].transform.gameObject.tag = "Wrong";
        }
        return array;
    }
}
