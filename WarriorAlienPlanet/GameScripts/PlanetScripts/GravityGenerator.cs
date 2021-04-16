using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGenerator : MonoBehaviour
{
    public float planetGravity = -60f; // Set the power of gravity
    
    public void GravityVectorProducer(Rigidbody warrior)
    {
        Vector3 directionCentral = (warrior.position - transform.position).normalized; // Create a vector between warrior and planet.
        Vector3 warriorYAxis = warrior.transform.up;
        warrior.rotation = Quaternion.FromToRotation(warriorYAxis, directionCentral) * warrior.rotation; // Rotation using Quaternion

        warrior.AddForce(directionCentral * planetGravity); // Use force to the warrior
    }
 
}
