using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    // TODOS LOS INGREDIENTES!
    public GameObject boteMayonesa;
    public GameObject boteMoztaza;
    public GameObject lechuga;
    public GameObject pan;
    public GameObject queso;
    public GameObject nada;

    // Método que regresa un array
    public GameObject[] GetRecipe (int recipe)
    {
        GameObject[] array;

        switch (recipe)
        {
            case 1:
                array = new GameObject[]
                {
                    pan,
                    pan,
                    pan,
                    queso,
                    queso,
                    queso,
                    nada,
                    nada,
                    nada
                };
                break;

            default:
                array = new GameObject[] { };
                break;
        }
        array = PutTags(array, 3, 3, 3);
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
