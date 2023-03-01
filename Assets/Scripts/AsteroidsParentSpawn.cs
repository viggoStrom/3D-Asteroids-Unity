using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsParentSpawn : MonoBehaviour
{
    public GameObject asteroidPrefab;
    private float spawnRate;
    Vector3 randomRotation;

    public float spawnDelay;
    public float spawnDistanceOffset;
    public float rotationValue;


    void Update()
    {
        transform.Rotate(randomRotation * Time.deltaTime);
        if (shouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        spawnRate = Time.time + spawnDelay;
        Vector3 spawnDirection = Random.insideUnitSphere.normalized * this.spawnDistanceOffset;
        Vector3 spawnPoint = this.transform.position + spawnDirection;
        Quaternion rotation = Quaternion.AngleAxis(Random.Range(-this.rotationValue, this.rotationValue), Vector3.left);

        Instantiate(this.asteroidPrefab, spawnPoint, rotation, transform);
    }

    private bool shouldSpawn()
    {
        return Time.time > spawnRate;
    }

    void Start()
    {
        randomRotation.x = Random.Range(-rotationValue, rotationValue);
        randomRotation.y = Random.Range(-rotationValue, rotationValue);
        randomRotation.z = Random.Range(-rotationValue, rotationValue);
    }

}
