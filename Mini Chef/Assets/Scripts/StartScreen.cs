using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    float currentPos;
    public float vel = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPos -= vel;

        if(currentPos <= -960)
        {
            currentPos = 0;
            GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        }

        GetComponent<RectTransform>().offsetMin = new Vector2(currentPos, 0);
    }
}
