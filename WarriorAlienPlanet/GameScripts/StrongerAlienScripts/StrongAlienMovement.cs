using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAlienMovement : MonoBehaviour
{
    public Transform warrior;
    public float alienSpeed = 3f;
    public float movementSpeed = 5f;
    private Rigidbody strongeralienRigidbody;
    private void Awake()
    {
        strongeralienRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 direction = (warrior.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction, transform.up);
        Quaternion smoothRotation = Quaternion.Slerp(transform.rotation, rotation, alienSpeed * Time.deltaTime);
        strongeralienRigidbody.MoveRotation(smoothRotation);

        strongeralienRigidbody.velocity = transform.forward * movementSpeed;
    }
}
