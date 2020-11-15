using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Gestures : MonoBehaviour
{
    // Vector de la distancia del objeto
    Vector3 dist;

    // Variables que guardan las posiciones X y Y
    float posX;
    float posY;

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
        // Se toma la posición del padre (de la base que tenía debajo)
        Vector3 cosa = transform.parent.GetComponent<Transform>().position;

        // Se le suman otra vez 3 en Z para que quede más arriba de la base
        transform.localPosition = new Vector3(0, 0, 3f);
    }

    // Método que ocurre cuando se mantiene presionado sobre un ingrediente (osea el movimiento)
    public void OnMouseDrag()
    {
        // No se que es esto pero funciona
        Vector3 curPos =
            new Vector3(Input.mousePosition.x - posX,
                        Input.mousePosition.y - posY, dist.z);

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
        transform.position = worldPos;
    }
}
