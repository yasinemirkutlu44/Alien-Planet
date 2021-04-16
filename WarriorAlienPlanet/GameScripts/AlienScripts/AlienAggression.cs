using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAggression : MonoBehaviour
{
    // Set the varaiables
    public float alienAttackPeriod = 0.4f;
    private int damageAmount = 10;
    private float awaitTimer;
    private bool aggressionDistance;
    private bool AlienIsAttacked;
    private Animator enemyAnimationTrigger;
    private AlienMovement alienMovement;
    private AlienHealth alienHealth;
    private WarriorHealth warriorHealth;

    private void Awake() // Get the appropriate component
    {
        warriorHealth = GameObject.FindGameObjectWithTag("Warrior").GetComponent<WarriorHealth>();
        alienMovement = GetComponent<AlienMovement>();
        enemyAnimationTrigger = GetComponent<Animator>();
        alienHealth = GetComponent<AlienHealth>();
    }

    private void FixedUpdate()
    {
        awaitTimer += Time.deltaTime;
        if (awaitTimer > alienAttackPeriod && aggressionDistance && AlienIsAttacked && alienHealth.instantHealth > 0) // Check the attacking criteria
        {
            AlienAggressionProcess();
        }

        enemyAnimationTrigger.SetBool("AlienIsAttacked", AlienIsAttacked);

        if (warriorHealth.instantHealth <=0 ) // Warrior is dead, stop attacking
        {
            enemyAnimationTrigger.SetTrigger("WarriorIsDead");
            alienMovement.enabled = false;
        }
    }

    private void AlienAggressionProcess() // If warrior is alive, then attack
    {
        awaitTimer = 0f;
        //enemyAnimationTrigger.SetBool("AlienIsAttacked", true);
        enemyAnimationTrigger.SetBool("AlienIsAttacked", AlienIsAttacked);

        if (warriorHealth.instantHealth >= 0)
        {
            warriorHealth.EnemyAttack(damageAmount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Warrior")
        {
            aggressionDistance = true;
            AlienIsAttacked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Warrior")
        {
            aggressionDistance = false;
            AlienIsAttacked = false;
        }
    }
}
