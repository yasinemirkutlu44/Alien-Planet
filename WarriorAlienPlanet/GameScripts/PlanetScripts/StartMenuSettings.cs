using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame() // Quit the game
    {
#if UNITY_EDITOR // Editor Test
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void NextScene() // Play button
    {
        SceneManager.LoadScene(1); // Once the users click Play button then Load the next scene (Sample scene)
    }
}
