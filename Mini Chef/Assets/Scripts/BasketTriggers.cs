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
        other.transform.localScale += new Vector3(.5f, .5f, .5f);
        text.GetComponent<Text>().text = "Está en la cesta";
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonUp(0))
        {
            switch(other.tag)
            {
                case "Needed":
                    text.GetComponent<Text>().text = "Ingrediente necesario";
                    break;
                case "Optional":
                    text.GetComponent<Text>().text = "Ingrediente opcional";
                    break;
                case "Wrong":
                    text.GetComponent<Text>().text = "Ingrediente incorrecto";
                    break;
                default:
                    text.GetComponent<Text>().text = "Hubo algo siniestro";
                    break;
            }
            other.gameObject.SetActive(false);
        }
    }

    // Método cuando algo sale de la canasta
    private void OnTriggerExit(Collider other)
    {
        other.transform.localScale -= new Vector3(.5f, .5f, .5f);
        text.GetComponent<Text>().text = "Salió de la cesta";
    }
}
