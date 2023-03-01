using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    public Image UICrosshair;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private float moveSpeed = 8f;
    private Vector3 targetPosition;

    // Update is called once per frame
    void Update()
    {
        // Get the position of the mouse in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Set the z coordinate to be the distance from the camera
        mousePosition.z = 20f;

        // Convert the screen coordinates to world coordinates
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Set the target position to the calculated world position
        targetPosition = worldPosition;

        // Move the crosshair towards the target position
        UICrosshair.transform.position = Vector3.Lerp(UICrosshair.transform.position, mousePosition, moveSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
