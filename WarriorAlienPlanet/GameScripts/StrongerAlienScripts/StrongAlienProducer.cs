using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAlienProducer : MonoBehaviour
{

    public GameObject strongAlien;
    public Transform[] productionPins;
    public float productionTimer = 3f;
    public WarriorHealth warriorHealth;
    private void Start()
    {
        InvokeRepeating("StrongAlienProduce", productionTimer, productionTimer);
    }
    private void StrongAlienProduce()
    {
        if (warriorHealth.instantHealth <= 0) return;

        int num = Random.Range(0, productionPins.Length);

        Instantiate(strongAlien, productionPins[num].position, productionPins[num].rotation);

    }
}
