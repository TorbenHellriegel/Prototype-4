using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPushForce : MonoBehaviour
{
    private float powerupMultiStrength = 25;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Checks for collisions
    private void OnCollisionEnter(Collision collision)
    {
        // If enemy collides with the player repell player
        if(collision.gameObject.name == "Player")
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromEnemy = collision.gameObject.transform.position - transform.position;
            playerRb.AddForce(awayFromEnemy * powerupMultiStrength, ForceMode.Impulse);
        }
    }
}
