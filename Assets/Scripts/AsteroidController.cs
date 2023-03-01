using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float mass;
    public float maxLifeTime;

    public float collisonDistanceOffset;

    public float minScale;
    public float maxScale;

    public float minSpeed;
    public float maxSpeed;

    public float rotationValue;
    public float rotationMagnifier;

    private Rigidbody rigidBody;

    Transform asteroidTransform;
    Vector3 randomRotation;

    private Vector3 randomMovement(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }

    private Vector3 randomScale(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }

    private float randomMass(float max)
    {   
            var m = Random.Range(1, max);
            return m;
    }


    private void CreateSplit()
    {
        Vector3 explosionPosition = this.asteroidTransform.position;
        explosionPosition = explosionPosition + Random.insideUnitSphere * collisonDistanceOffset;
        AsteroidController half = Instantiate(this, explosionPosition, this.asteroidTransform.rotation);

        half.asteroidTransform.localScale = new Vector3((this.asteroidTransform.localScale.x * 0.5f), (this.asteroidTransform.localScale.y * 0.5f), (this.asteroidTransform.localScale.y * 0.5f));
        half.mass = this.mass * 0.5f;
        half.GetComponent<Rigidbody>().mass = half.mass;
        half.GetComponent<Rigidbody>().velocity = randomMovement(minSpeed, maxSpeed);

        this.asteroidTransform.localScale = new Vector3((this.asteroidTransform.localScale.x * 0.5f), (this.asteroidTransform.localScale.y * 0.5f), (this.asteroidTransform.localScale.y * 0.5f));
        this.mass *= 0.5f;
        this.GetComponent<Rigidbody>().mass = this.mass;
        this.GetComponent<Rigidbody>().velocity = randomMovement(minSpeed, maxSpeed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroids")
        {
            if ((this.mass * 0.5f) >= 1)
            {
                CreateSplit();
            }
            else 
            {
                Destroy(this.gameObject);
            }  
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Asteroids")
    //    {
    //     Destroy(this.gameObject);  
    //    }
    //}

    private void Awake()
    {
        asteroidTransform = transform;
    }

    private void Start()
    {
        //Instantiates a Random rotation for the gameObject
        randomRotation.x = Random.Range(-rotationValue, rotationValue);
        randomRotation.y = Random.Range(-rotationValue, rotationValue);
        randomRotation.z = Random.Range(-rotationValue, rotationValue);


        asteroidTransform.localScale = randomScale(minScale, maxScale);
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.mass = randomMass(mass);
        rigidBody.velocity = randomMovement(minSpeed, maxSpeed);
        Destroy(this.gameObject, maxLifeTime);

    }

    private void Update()
    {
        asteroidTransform.Rotate(randomRotation * Time.deltaTime * rotationMagnifier);  
    }

}