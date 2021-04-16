using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienProcuder : MonoBehaviour
{
    public GameObject alien;
    public Transform[] productionPins;
    public float productionTimer = 2f;
    public WarriorHealth warriorHealth;

    private void Start()
    {
        InvokeRepeating("Produce", productionTimer, productionTimer); // Call the Produce method anytime.
    }

    private void Produce()
    {
        if(warriorHealth.instantHealth <= 0) return; // If warrior is dead, stop producing

        int num = Random.Range(0, productionPins.Length);

        Instantiate(alien, productionPins[num].position, productionPins[num].rotation);
      
    }

}
