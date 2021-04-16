using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienHealth : MonoBehaviour
{
    private int alienInitialHealth = 100;
    public int instantHealth;
    public AudioClip alienDeadMusic;
    private AlienMovement alienMovement;
    private Animator alienAnimation;
    private AudioSource audioSource;
    private new ParticleSystem particleSystem;
    private CapsuleCollider capsuleCollider;
    private bool isAlienDead;

    private void Awake()
    {
        alienAnimation = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        alienMovement = GetComponent<AlienMovement>();
        instantHealth = alienInitialHealth;
    }

    public void WarriorAttack(int damage, Vector3 beatPoint) // If warrior is attack, reduce the current health of aliens.
    {
        if (isAlienDead) return;
        audioSource.Play();
        instantHealth -= damage; // Reduce

        particleSystem.transform.position = beatPoint;
        particleSystem.Play();

        if(instantHealth <=0) // If alien is dead
        {
            AlienDead(); // Trigger animation, set dead true.
        }

    }

    private void AlienDead()
    {
        isAlienDead = true;
        //capsuleCollider.enabled = false;
        alienMovement.enabled = false;
        alienAnimation.SetTrigger("AlienIsDead");
        audioSource.clip = alienDeadMusic;
        ScoreController.gameScore += 20; // Update the score
        audioSource.Play();
    }

}
