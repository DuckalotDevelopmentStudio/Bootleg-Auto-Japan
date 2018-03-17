using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [Header("Customzable Attributtes")]
    public int speed = 5;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        rb.velocity += transform.forward * speed ;//Moves bullets
    }
    private void OnBecameInvisible()
    {
        DestroyObject(gameObject);
    }

    private void OnCollisionEnter(Collision collision) //Checks for collison
    {
        DestroyObject(gameObject);
    }
}

