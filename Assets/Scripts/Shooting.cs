using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject ProjectileParent;
    public GameObject ProjectilePrefab;
    public GameObject Crosshair;
    public float Firerate = 2f; // seconds per shot
    private float deltaTime;

    private void Start()
    {
        deltaTime = 1f;

    }
    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && deltaTime >= Firerate)
        {
            deltaTime = 0f;
            Vector3 direction = Crosshair.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            Instantiate(ProjectilePrefab, transform.position, rotation, ProjectileParent.transform);
        }
    }
}
