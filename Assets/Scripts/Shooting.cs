using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject ProjectileParent;
    public GameObject ProjectilePrefab;
    public GameObject Crosshair;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 direction = Crosshair.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            Instantiate(ProjectilePrefab, transform.position, rotation, ProjectileParent.transform);
        }
    }
}
