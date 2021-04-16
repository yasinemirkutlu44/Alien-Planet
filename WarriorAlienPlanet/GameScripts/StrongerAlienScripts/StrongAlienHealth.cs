using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAlienHealth : MonoBehaviour
{

    private int alienInitialHealth = 100;
    public int instantHealth;
    public AudioClip alienDeadMusic;
    private StrongAlienMovement strongAlienMovement;
    private AudioSource audioSource;
    private CapsuleCollider capsuleCollider;
    private new ParticleSystem particleSystem;
    private bool isAlienDead;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        strongAlienMovement = GetComponent<StrongAlienMovement>();
        instantHealth = alienInitialHealth;
    }

    public void WarriorAttack(int damage, Vector3 beatPoint)
    {
        if (isAlienDead) return;
        audioSource.Play();
        instantHealth -= damage;

        particleSystem.transform.position = beatPoint;
        particleSystem.Play();

        if (instantHealth <= 0)
        {
            StrongAlienDead();
            transform.gameObject.SetActive(false);
        }

    }

    private void StrongAlienDead()
    {
        isAlienDead = true;
        //capsuleCollider.enabled = false;
        strongAlienMovement.enabled = false;
        audioSource.clip = alienDeadMusic;
        ScoreController.gameScore += 40;
        audioSource.Play();
    }
}
