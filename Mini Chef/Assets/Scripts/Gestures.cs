using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Gestures : MonoBehaviour
{
    // Vector de la distancia del objeto
    Vector3 dist;

    // Vector de la posición inicial
    Vector3 startPosition;

    // Variables que guardan las posiciones X y Y
    float posX;
    float posY;

    // Mucho texto
    //public GameObject text;

    private void Awake()
    {
        //startPosition = transform.position;
        //text = GameObject.Find("Text");
    }

    // Método que ocurre cuando se presiona un ingrediente
    void OnMouseDown()
    {
        dist = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;
    }

    // Método que ocurre cuando se suelta un ingrediente
    private void OnMouseUp()
    {
        Vector3 cosa = transform.parent.GetComponent<Transform>().position;
        //transform.position = cosa; //transform.parent.GetComponent<Transform>().position;
        transform.localPosition = new Vector3(0, 20f, 0);
    }

    // Método que ocurre cuando se mantiene presionado sobre un ingrediente
    void OnMouseDrag()
    {
        Vector3 curPos =
         new Vector3(Input.mousePosition.x - posX,
                     Input.mousePosition.y - posY, dist.z);

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
        transform.position = worldPos;
    }

    // Método cuando se acerca a una canasta
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Basket")
        {
            transform.localScale += new Vector3(.5f, 10f, .5f);
            //text.GetComponent<Text>().text = "Está en la cesta";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Basket")
        {
            transform.localScale -= new Vector3(.5f, 10f, .5f);
            //text.GetComponent<Text>().text = "Salió de la cesta";
        }
    }
    /*if(other.tag == "Basket")
    {
        transform.localScale = new Vector3(2f, 2f, 2f);
    }*/
}
