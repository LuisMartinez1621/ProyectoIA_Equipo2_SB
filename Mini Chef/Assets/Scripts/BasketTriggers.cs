using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketTriggers : MonoBehaviour
{
    // GameObject Text
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Método cuando se acerca a una canasta
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ingredient")
        {
            other.transform.localScale += new Vector3(.5f, .5f, .5f);
            text.GetComponent<Text>().text = "Está en la cesta";
        }
    }

    // Método cuando algo sale de la canasta
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ingredient")
        {
            other.transform.localScale -= new Vector3(.5f, .5f, .5f);
            text.GetComponent<Text>().text = "Salió de la cesta";
        }
    }
}
