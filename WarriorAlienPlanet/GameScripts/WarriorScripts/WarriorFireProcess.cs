using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorFireProcess : MonoBehaviour
{

    public float fireTimer = 0.2f;
    public int harm = 25;
    public float firedistance = 200f;
    private float gameTimer;
    private AlienHealth alienHealthInstance;
    private StrongAlienHealth strongAlienHealthInstance;
    private AudioSource audioSource;
    private new ParticleSystem particleSystem;
    private Light fireLight;
    private LineRenderer fireLightRenderer;
    private float destroyEffect = 0.1f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponent<ParticleSystem>();
        fireLight = GetComponent<Light>();
        fireLightRenderer = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        gameTimer += Time.deltaTime;

        if(Input.GetButton("Fire1") && gameTimer > fireTimer)
        {

            Fire();
        }

        if(gameTimer > fireTimer * destroyEffect)
        {
            fireLightRenderer.enabled = false;
            fireLight.enabled = false;
        }
    }

    private void Fire()
    {
        gameTimer = 0f;
        audioSource.Play();
        fireLight.enabled = true;
        particleSystem.Stop();
        particleSystem.Play();
        fireLightRenderer.enabled = true;
        fireLightRenderer.SetPosition(0, transform.position);

        Ray rayLine = new Ray();
        RaycastHit raycastHit;
        rayLine.origin = transform.position;
        rayLine.direction = transform.forward;
        if(Physics.Raycast(rayLine, out raycastHit, firedistance))
        {
            alienHealthInstance = raycastHit.collider.GetComponent<AlienHealth>();
            strongAlienHealthInstance = raycastHit.collider.GetComponent<StrongAlienHealth>();
            if(alienHealthInstance != null)
            {
                alienHealthInstance.WarriorAttack(harm, raycastHit.point);
                //strongAlienHealthInstance.WarriorAttack(harm, raycastHit.point);
            }
            else if (strongAlienHealthInstance != null )
            {
                strongAlienHealthInstance.WarriorAttack(harm, raycastHit.point);
            }
            else
            {
                return;
            }
            fireLightRenderer.SetPosition(1, raycastHit.point);
        }

    }

}
