using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [Header("Customzable Attributtes")]
    public int speed = 5;
    // Update is called once per frame
    void FixedUpdate () {

        GetComponent<Rigidbody>().velocity += transform.forward * speed;//Moves bullets
    }

    private void OnCollisionEnter(Collision collision) //Checks for collison
    {
        if (collision.gameObject.tag == "Friendly") //To change
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>()); //Ignore friendly gameobjects
        } else
        {
            Destroy(gameObject);//Destroys bullet on impact 
            /*
             * Add Objct Pool
            */
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject); //Destroy bullet when not visible
    }
}

