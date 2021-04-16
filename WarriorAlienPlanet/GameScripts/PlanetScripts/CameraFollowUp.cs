using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowUp : MonoBehaviour
{
    public Transform warrior; // Variables
    public float yPoint;
    public float zPoint;
    public float cameraSpeed;
    public float rotationSpeed;

    
    
    
    private void FixedUpdate()
    {
        Vector3 nextPosition = warrior.TransformPoint(0, yPoint, -zPoint); // Create a point above the warrior. 
        transform.position = Vector3.Lerp(transform.position, nextPosition, cameraSpeed * Time.deltaTime);

        Vector3 cameraDirection = warrior.position - transform.position;
        Quaternion nextRotation = Quaternion.LookRotation(cameraDirection, warrior.up); // Rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, nextRotation, rotationSpeed * Time.deltaTime); // Adjust the rotation.
    }

}
