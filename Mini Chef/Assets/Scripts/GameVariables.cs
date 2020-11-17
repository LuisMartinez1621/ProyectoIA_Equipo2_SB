using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameVariables : MonoBehaviour
{
    // Cosas
    public static GameVariables gameVariables;

    // Nivel elegido
    public int level1Recipe = 0;

    //Awakakake
    private void Awake()
    {
        if(gameVariables == null)
        {
            gameVariables = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(gameVariables != this)
            {
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
