using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnded : MonoBehaviour
{

    private Animator canvasAnimator;
    public WarriorHealth warriorHealth;
    private AudioSource gameOverSound;


    private void Awake() // Get appropriate components
    {
        canvasAnimator = GetComponent<Animator>();
        gameOverSound = GetComponent<AudioSource>();
    }



    private void FixedUpdate()
    {
        if(warriorHealth.instantHealth <=0) // If warrior's health is less than 0 then Game is over
        {
            canvasAnimator.SetTrigger("GameIsEnded");
            //gameOverSound.clip = GameOver
        }
        //gameOverPlay();
    }

    private void gameOverPlay()
    {
        if(warriorHealth.instantHealth <= 0) // If game is over then play the music. This method is not used. Instead, the whole game over animation will take place 
        {
            gameOverSound.Play();
        }
    }
}
