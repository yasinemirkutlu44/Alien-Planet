using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAlienAggression : MonoBehaviour
{

    public float strongAlienAttackPeriod = 0.2f;
    private int damageAmount = 20;
    private float awaitTimer;
    private bool aggressionDistance;
    private bool AlienIsAttacked;
    private StrongAlienMovement strongAlienMovement;
    private StrongAlienHealth strongAlienHealth;
    private WarriorHealth warriorHealth;

    private void Awake()
    {
        warriorHealth = GameObject.FindGameObjectWithTag("Warrior").GetComponent<WarriorHealth>();
        strongAlienMovement = GetComponent<StrongAlienMovement>();
        strongAlienHealth = GetComponent<StrongAlienHealth>();
    }

    private void FixedUpdate()
    {
        awaitTimer += Time.deltaTime;
        if (awaitTimer > strongAlienAttackPeriod && aggressionDistance && AlienIsAttacked && strongAlienHealth.instantHealth > 0)
        {
            StrongAlienAggressionProcess();
        }

        if (warriorHealth.instantHealth <= 0)
        {
            strongAlienMovement.enabled = false;
        }
    }

    private void StrongAlienAggressionProcess()
    {
        awaitTimer = 0f;

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
