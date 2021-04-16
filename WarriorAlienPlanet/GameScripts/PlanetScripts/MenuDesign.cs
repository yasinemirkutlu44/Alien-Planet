using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDesign : MonoBehaviour
{

    public GameObject menuDesignCanvas;
    private bool isGameStopped = false;


    void Start()
    {
        
    }

    void Update() // Escape button - Game pause menu - Animation set
    {
        if (Input.GetKeyDown(KeyCode.Escape)) isGameStopped = !isGameStopped;
        if (isGameStopped)
        {
            Time.timeScale = 0f;
            menuDesignCanvas.SetActive(true);
        }
        if(!isGameStopped)
        {
            Time.timeScale = 1f;
            menuDesignCanvas.SetActive(false);
        }
    }

    public void ExitGame() // Quit button - Exit game 
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
#endif
    }

    public void CarryOnGame() // Carry on playing
    {
        isGameStopped = false;
    }

}
