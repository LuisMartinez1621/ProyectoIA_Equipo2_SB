using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients2 : MonoBehaviour
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

    // Arreglo donde se guardarán los GameObjects del nivel
    public GameObject[] array;

    // Arreglo donde se guardarán los íconos del nivel
    public String[] icons;

    // Arreglo de las cantidades
    public float[] quantity;

    // Método que inicializa el arreglo con la cantidad de elementos requeridos
    public GameObject[] SetLength()
    {
        // Se establece la receta del nivel
        SetRecipeNumber();

        switch (recipe)
        {
            case 1:
                return new GameObject[6];
            case 2:
                return new GameObject[7];
            case 3:
                return new GameObject[6];
            case 4:
                return new GameObject[5];
            case 5:
                return new GameObject[5];
            default:
                return new GameObject[0];
        }
    }

    // Método para obtener la lista de ingredientes con sus prefabs
    internal void GetRecipe()
    {
        // Se establece la receta del nivel
        SetRecipeNumber();

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
                    lechuga
                };

                icons = new String[]
                {
                    "Ingredients/Jamon",
                    "Ingredients/Pan",
                    "Ingredients/Queso",
                    "Ingredients/Mayonesa",
                    "Ingredients/Mostaza",
                    "Ingredients/Lechuga"
                };

                quantity = new float[]
                {
                    2, 2, 1, 3, 1, 2
                };

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
                    sal
                };

                icons = new String[]
                {
                    "Ingredients/Huevo",
                    "Ingredients/Jamon",
                    "Ingredients/Leche",
                    "Ingredients/Mantequilla",
                    "Ingredients/Pimienta",
                    "Ingredients/Queso",
                    "Ingredients/Sal"
                };

                quantity = new float[]
                {
                    3, 2, 1, 2, 1, 1, 2
                };
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
                    sal
                };

                icons = new String[]
                {
                    "Ingredients/Atun",
                    "Ingredients/Verduras",
                    "Ingredients/Crema",
                    "Ingredients/Mayonesa",
                    "Ingredients/Pimienta",
                    "Ingredients/Sal"
                };

                quantity = new float[]
                {
                    2, 1, 1, 3, 1, 2
                };

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
                    pasas
                };

                icons = new String[]
                {
                    "Ingredients/Agua",
                    "Ingredients/Arroz",
                    "Ingredients/Leche",
                    "Ingredients/Canela",
                    "Ingredients/Pasas"
                };

                quantity = new float[]
                {
                    1, 3, 3, 2, 1
                };

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
                    miel
                };

                icons = new String[]
                {
                    "Ingredients/Harina",
                    "Ingredients/Huevo",
                    "Ingredients/Leche",
                    "Ingredients/Mantequilla",
                    "Ingredients/Miel",
                };

                quantity = new float[]
                {
                    2, 2, 3, 2, 1
                };

                break;

            default:
                array = new GameObject[] { };
                icons = new String[] { };
                break;
        }
    }

    // Método para asignar la variable de la receta
    void SetRecipeNumber()
    {
        // Se hace referencia al script que contiene las variables del juego
        gameVariables = GameObject.Find("GameVariables").GetComponent<GameVariables>();

        // Se establece la receta del nivel
        recipe = gameVariables.recipe;
    }
}
