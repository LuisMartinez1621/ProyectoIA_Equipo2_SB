using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gestures : MonoBehaviour
{
    // Vector de la distancia del objeto
    Vector3 dist;

    // Vector de la posición inicial
    Vector3 startPosition;

    // Variable del asset
    //public GameObject target;

    // Variables que guardan las posiciones X y Y
    float posX;
    float posY;

    private void Awake()
    {
        //startPosition = transform.position;
    }

    void OnMouseDown()
    {
        dist = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - dist.x;
        posY = Input.mousePosition.y - dist.y;
    }

    private void OnMouseUp()
    {
        Vector3 cosa = transform.parent.GetComponent<Transform>().position;
        //transform.position = cosa; //transform.parent.GetComponent<Transform>().position;
        transform.localPosition = new Vector3(0, 20f, 0);
    }

    void OnMouseDrag()
    {
        Vector3 curPos =
         new Vector3(Input.mousePosition.x - posX,
                     Input.mousePosition.y - posY, dist.z);

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
        transform.position = worldPos;
    }
}
