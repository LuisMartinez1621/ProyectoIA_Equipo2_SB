using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestures2 : MonoBehaviour
{
    // Velocidad de la rotación
    public float rotSpeed = 300;

    // Variables que ayuda con algunas cosas
    public int status = 0;
    public int position = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Código para hacer rotar los ingredientes
    void OnMouseDrag()
    {
        if (status == 1)
        {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            transform.Rotate(Vector3.forward, -rotX);
        }
    }

    // Método que hará aparecer sólo un ingrediente en el centro
    void OnMouseDown()
    {
        // Cosa para evitar que se pique de nuevo
        if (status == 0)
        {
            // Se cambia la variable de estado
            status = 1;

            // Zona peligrosa!
            GameObject.Find("GameManager").GetComponent<Level2Manager>().DissapearIngredients(position);
        }
    }
}
