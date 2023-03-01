using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float ProjectileSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(ProjectileSpeed * Time.deltaTime * Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroids"))
        {
            Destroy(this.gameObject);
        }
    }
}
