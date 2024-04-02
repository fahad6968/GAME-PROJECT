using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7.0f; // Speed of the player
    private Rigidbody playerRigidbody; // Reference to the player's Rigidbody

    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        playerRigidbody = GetComponent<Rigidbody>();

        // Constrain the Rigidbody to prevent the player from falling over
        playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += move * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a Rigidbody component
        if (collision.rigidbody != null)
        {
            // The player has collided with a Rigidbody
            Debug.Log("Collided with a Rigidbody!");
        }
    }
}