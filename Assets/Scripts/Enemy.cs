using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyRb;

    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Makes the enemy move towards the player
        Vector3 lookDirection = MoveDirection();
        enemyRb.AddForce(lookDirection * speed);
    }

    // Returns the direction the enemy is supposed to move in
    private Vector3 MoveDirection()
    {
        float lookDirectionX = player.transform.position.x - transform.position.x;
        float lookDirectionZ = player.transform.position.z - transform.position.z;

        return new Vector3(lookDirectionX, 0, lookDirectionZ).normalized;
    }
}
