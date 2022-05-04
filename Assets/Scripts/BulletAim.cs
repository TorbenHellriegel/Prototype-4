using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAim : MonoBehaviour
{
    private Rigidbody bulletRb;
    public Vector3 enemyPosition = new Vector3(0, 0, 0);
    private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // Move bullet in the directon of the enemy
        Vector3 lookDirection = (enemyPosition - transform.position).normalized;
        bulletRb.AddForce(lookDirection * speed, ForceMode.VelocityChange);
    }

    // Checks for collisions
    private void OnCollisionEnter(Collision collision)
    {
        // If bullet collides with enemy repell enemy
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPLayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPLayer * speed * 2, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
