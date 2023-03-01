using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    public float LookSpeed = 1f;
    public float RollSpeed = 30f;
    public float FlightSpeed = 3f;
    public float DeadZoneAngle = 5f;

    [SerializeField] private Transform crosshair;
    private new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroids"))
        {
            // ui stuff
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get the direction from the ship to the crosshair
        Vector3 direction = crosshair.position - transform.position;

        float angleDelta = Vector3.Angle(transform.forward, direction);

        if (angleDelta > DeadZoneAngle)
        {
            // Calculate the rotation needed to face the direction
            Quaternion lookRotation = Quaternion.LookRotation(direction, transform.up);

            // Apply the rotation to the ship
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, LookSpeed * Time.deltaTime);
        }

        // Roll the ship when A or D are pressed
        float rollInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.forward, -rollInput * RollSpeed * Time.deltaTime);

        transform.Translate(FlightSpeed * Time.deltaTime * Vector3.forward);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            FlightSpeed += 3;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            FlightSpeed -= 3;
        }
    }
}
