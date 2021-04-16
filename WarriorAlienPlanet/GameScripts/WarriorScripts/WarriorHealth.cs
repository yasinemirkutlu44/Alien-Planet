using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarriorHealth : MonoBehaviour
{
    // Create the variables
    private int warriorInitialHealth = 100;
    public int instantHealth;
    public Slider healthvalueSlider;
    public AudioClip warriorDeadMusic;
    private AudioSource audioSource;
    private AudioSource warriorDeathSource;
    public Image damageImage;
    private bool isWarriorDead;
    private bool isEnemyAttacked;
    private float imageSpeed = 0.3f;
    private void Awake()
    {
        instantHealth = warriorInitialHealth; // Get the appropriate components
        audioSource = GetComponent<AudioSource>();
        warriorDeathSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(isEnemyAttacked) // Enemy is attacked, damage, current health decrease
        {
            damageImage.color = new Color(0.8f,0.1f,0.1f,0.2f); // Create a color instance
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, imageSpeed * Time.deltaTime);
        }
        isEnemyAttacked = false;
        
    }

    public void EnemyAttack(int damage)
    {
        isEnemyAttacked = true;
        instantHealth -= damage; // Reduce the health
        healthvalueSlider.value = instantHealth;

        //audioSource.Play();

        if(instantHealth <=0 && !isWarriorDead) // Warrior is dead
        {
            //WarriorDeathSource();
            WarriorDead();
            //gameOverSource.Play();
        }

    }

    private void WarriorDead()
    {
        isWarriorDead = true;
        //gameOverSource.Play();
        transform.gameObject.SetActive(false);
        //audioSource.clip = warriorDeadMusic;
        //audioSource.Play();
        //gameOverSource.Play();
    }

    private void WarriorDeathSource() // This is not used. Game over animation will take place.
    {
        warriorDeathSource.Play();
    }



}
