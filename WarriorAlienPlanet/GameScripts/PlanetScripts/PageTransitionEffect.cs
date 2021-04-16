using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PageTransitionEffect : MonoBehaviour
{
    private Image sceneTransitionImage;
    private Color transitionColour = new Color(91, 87, 87);
    public float transitionSceneTime;


    private void Awake()
    {
        sceneTransitionImage = GetComponent<Image>(); // Get the appropriate component
    }

    
    void Update() // Once the transition is completed between 1st and 2nd scene, fade the image and provide a smooth transition.
    {
        if(Time.timeSinceLevelLoad < transitionSceneTime)
        {
            float value = Time.deltaTime / transitionSceneTime;
            transitionColour.a -= value;
            sceneTransitionImage.color = transitionColour;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
