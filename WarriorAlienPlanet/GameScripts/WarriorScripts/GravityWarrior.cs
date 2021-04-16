using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWarrior : MonoBehaviour
{
    private Rigidbody warriorRigid;
    private GravityGenerator gravityCollectorPlanet;
    private void Awake()
    {
        warriorRigid = GetComponent<Rigidbody>(); // Get appropriate component
        gravityCollectorPlanet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityGenerator>(); // Find the tag "Planet" and get its component
        warriorRigid.useGravity = false;
        warriorRigid.constraints = RigidbodyConstraints.FreezeRotation; // Constrain the rotation.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gravityCollectorPlanet.GravityVectorProducer(warriorRigid); // Apply the method.
    }
}
