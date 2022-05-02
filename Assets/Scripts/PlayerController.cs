using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerupIndicator;

    public bool hasPowerupMulti = false;
    private float powerupMultiStrength = 15;
    public float speed = 1;
    public float pushForce = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the powerup along with the player
        powerupIndicator.gameObject.transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);

        // Move the player 
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        // Gives the player a stong push in the direction the camera is facing
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(focalPoint.transform.forward * forwardInput * pushForce, ForceMode.Impulse);
        }
    }

    // Checks for trigges
    private void OnTriggerEnter(Collider other)
    {
        // If the player collides with multiply powerup activate it
        if(other.CompareTag("PowerupMulti"))
        {
            hasPowerupMulti = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine("PowerupCountdownRoutine");
        }
    }

    // Counts down until the powerup dissapears
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerupMulti = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    // Checks for collisions
    private void OnCollisionEnter(Collision collision)
    {
        // If player collides with enemy while having powerup repell enemy
        if(collision.gameObject.CompareTag("Enemy") && hasPowerupMulti)
        {
            Rigidbody enemyRigidbode = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPLayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbode.AddForce(awayFromPLayer * powerupMultiStrength, ForceMode.Impulse);
            //gg
        }
    }
}
