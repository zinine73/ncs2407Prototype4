using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5.0f;
    public bool hasPowerUp;
    private GameObject focalPoint;
    private float powerupStrength = 15.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
        focalPoint = GameObject.Find("FocalPoint");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("POWER_UP"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ENEMY") && hasPowerUp)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log("Collided with " + collision.gameObject.name
             + " with powerup set to " + hasPowerUp);
        }
    }
}
