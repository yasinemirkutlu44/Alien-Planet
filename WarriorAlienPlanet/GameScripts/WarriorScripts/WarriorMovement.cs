using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMovement : MonoBehaviour
{
    public float warriorSpeed = 10f;
    public float pointDistance = 50f;
    public float rotationSpeed = 5f;
    public LayerMask layer;
    private Rigidbody warriorRigid;
    private Vector3 warriorMovement;
    private Vector3 moveTarget;
    private Vector3 smoothVelocity;
    private Animator warriorAnimator;

    private void Awake()
    {
        warriorRigid = GetComponent<Rigidbody>();
        warriorAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate() // Get Horizontal and Vertical values.
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        MoveWarrior(horizontal, vertical);
        RotateWarrior();
        RunAnimation(horizontal, vertical);

    }

    private void MoveWarrior(float horizontal, float vertical) // Move the warrior 
    {

        warriorMovement = new Vector3(horizontal, 0, vertical).normalized; // Create a vector instance.
        warriorMovement = warriorMovement * warriorSpeed * Time.deltaTime; // Adjust with speed.
        moveTarget = Vector3.SmoothDamp(moveTarget, warriorMovement, ref smoothVelocity, .10f);

        warriorRigid.MovePosition(warriorRigid.position + transform.TransformDirection(moveTarget)); // Move the character
    }

    private void RotateWarrior()
    {
        Ray rayLine = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        if (Physics.Raycast(rayLine, out raycastHit, pointDistance, layer))
        {
            Vector3 direction = raycastHit.point - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction, transform.up);
            Quaternion smoothRotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            warriorRigid.MoveRotation(smoothRotation);
        }
    }

    private void RunAnimation(float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0) // Warrior moves then change the status from Idle to Run.
        {
            warriorAnimator.SetBool("RunAnimation", true);
        }
        else
        {
            warriorAnimator.SetBool("RunAnimation", false);
        }
    }
}
