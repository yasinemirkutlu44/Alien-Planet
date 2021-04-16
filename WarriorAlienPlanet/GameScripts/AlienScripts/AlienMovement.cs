using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    // Set the variables
    public Transform warrior;
    public float alienSpeed = 3f;
    public float movementSpeed = 5f;
    private Rigidbody alienRigid;

    private void Awake() // Get the appropriate components
    {
        alienRigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = (warrior.position - transform.position).normalized; // Create a vector between warrior and itself
        Quaternion rotation = Quaternion.LookRotation(direction, transform.up); 
        Quaternion smoothRotation = Quaternion.Slerp(transform.rotation, rotation, alienSpeed * Time.deltaTime); // Adjust a smooth rotation 
        alienRigid.MoveRotation(smoothRotation);

        alienRigid.velocity = transform.forward * movementSpeed; // Adjust with speed and follow
    }
}
